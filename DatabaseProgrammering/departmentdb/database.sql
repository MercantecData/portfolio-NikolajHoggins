/********************************************/
/*Hele Databasen sættes op ud fra denne fil.*/
/********************************************/

/*Set up database, but delete first if exists.*/
DROP DATABASE IF EXISTS departmentdb;
CREATE DATABASE departmentdb;

USE departmentdb;

/*Salaries is set up with the salary, and is to be used to define titles salaries*/
CREATE TABLE salaries(
    sal_id int AUTO_INCREMENT,
    monthly_salary double,
    PRIMARY KEY (sal_id)
);

/*Titles have a salary in them, a title name and is to be used on an employee.*/
CREATE TABLE titles(
    title_id int AUTO_INCREMENT,
    sal_id int,
    title_name varchar(32),
    PRIMARY KEY (title_id),
    FOREIGN KEY (sal_id) 
        REFERENCES salaries(sal_id)
);

/**/
CREATE TABLE employee(
    employee_id int AUTO_INCREMENT,
    title_id int,
    employee_name varchar(32) NOT NULL,
    employee_age int NOT NULL,
    employee_address varchar(64) NOT NULL,
    employed_years int,
    PRIMARY KEY (employee_id),
    FOREIGN KEY (title_id) REFERENCES titles(title_id)
);

CREATE TABLE department(
    dep_id int AUTO_INCREMENT,
    dep_name varchar(32) NOT NULL,
    PRIMARY KEY (dep_id)
);

CREATE TABLE dep_manager(
    manager_id int AUTO_INCREMENT,
    employee_id int,
    dep_id int,
    PRIMARY KEY (manager_id),
    FOREIGN KEY (employee_id) REFERENCES employee(employee_id) ON DELETE CASCADE,
    FOREIGN KEY (dep_id) REFERENCES department(dep_id)
);

CREATE TABLE dep_employee(
    d_employee_id int AUTO_INCREMENT,
    employee_id int,
    dep_id int,
    PRIMARY KEY (d_employee_id),
    FOREIGN KEY (employee_id) REFERENCES employee(employee_id) ON DELETE CASCADE,
    FOREIGN KEY (dep_id) REFERENCES department(dep_id)
);

/*Allows us to create fucktions*/
SET GLOBAL log_bin_trust_function_creators = 1;

DELIMITER $$
/*This fucntion is used to find if of title by the title name*/
CREATE FUNCTION `getTitleId` (param VARCHAR(32)) RETURNS int
BEGIN
  DECLARE title_id_found int;
    SELECT `title_id`
      INTO title_id_found
      FROM `titles`
     WHERE `title_name` = param;
    RETURN title_id_found;
END $$

/*Denne procedure henter en masse information om manageren af given department by ID*/
CREATE PROCEDURE getDepartmentManager(depId int)
BEGIN
    SELECT 
        dm.manager_id AS 'Manager ID', 
        department.dep_name AS 'Department',
        employee.employee_name AS 'Name',
        employee.employee_age AS 'Age',
        employee.employee_address AS 'Address',
        employee.employed_years,
        salaries.monthly_salary AS 'Monthly salary in DKK'
    FROM dep_manager AS dm 
        INNER JOIN employee 
            ON employee.employee_id = dm.employee_id
        INNER JOIN titles 
            ON titles.title_id = employee.title_id
        INNER JOIN salaries 
            ON salaries.sal_id = titles.sal_id
        INNER JOIN department
            ON dm.dep_id = department.dep_id
    WHERE dm.dep_id = depID;
END $$
DELIMITER ;


/*Creating a few departments*/
INSERT INTO department(dep_name) VALUES
('Texas Department'),
('Minnesota Department'),
('New York Department');

/**/
INSERT INTO salaries(monthly_salary) VALUES
(11300.00),
(24000.00),
(38000.00),
(56000.00),
(72000.00);

INSERT INTO titles(title_name, sal_id) VALUES
('Janitor', 2),
('Lead Dev', 4),
('Manager', 5),
('Programmer Apprentience', 1),
('Programmer', 3),
('It-supporter', 2);

INSERT INTO employee(title_id, employee_name, employee_age, employee_address, employed_years) VALUES
(getTitleId('Lead Dev'), 'Rasmus Kjeldsen', 26, 'Normansvej 1, 8900, Randers', 8),
(getTitleId('Programmer Apprentience'), 'Nikolaj Hoggins', 17, 'Hans Tausens Vej 22, 8800, Viborg', 1),
(getTitleId('Janitor'), 'Per Persen', 54, 'Brovej 43, 8900, Randers', 17),
(getTitleId('Programmer'), 'Progra Møhr', 22, 'Kodevej 7, 1113, København', 3),
(getTitleId('Manager'), 'Mike Møller', 29, 'Vejnavn 14, 8900, Randers', 5),
(getTitleId('Lead Dev'), 'Jonas Larsen', 26, 'kjasfkljsaf 1, 8900, Randers', 9),
(getTitleId('Programmer Apprentience'), 'Magnus Nielsen', 18, 'sdfsdfsdf vej 22, 8800, Viborg', 1),
(getTitleId('Janitor'), 'Mads Petersen', 35, 'Jernbanegade 15, 2312, Aablorg', 4),
(getTitleId('Programmer'), 'Kim Jespersen', 51, 'Bip Bop 2, 5430, Djursland', 6),
(getTitleId('Manager'), 'Rene Larsen', 32, 'SuperCoolVej 42, 3221, Rødkjærsbro', 13),
(getTitleId('Lead Dev'), 'Jeppe Vad', 43, 'adasfaf 1, 4322, København', 21),
(getTitleId('Programmer Apprentience'), 'Oliver Kaspersen', 16, 'sdfsdfsdf vej 22, 8800, Viborg', 1),
(getTitleId('Janitor'), 'Mikkel Madsen', 62, 'Jernbanegade 15, 2312, Aablorg', 14),
(getTitleId('Programmer'), 'Martin Juul', 23, 'Bip Bop 2, 5430, Djursland', 2),
(getTitleId('Manager'), 'Henrik Hansen', 41, 'SuperCoolVej 42, 3221, Rødkjærsbro', 2);

INSERT INTO dep_employee(employee_id, dep_id) VALUES
/*Putting 4 employees in each department*/
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(6, 2),
(7, 2),
(8, 2),
(9, 2),
(11, 3),
(12, 3),
(13, 3),
(14, 3);

INSERT INTO dep_manager(employee_id, dep_id) VALUE
(5,1),
(10,2),
(15, 3);

CREATE VIEW getEmployeeInformation AS
SELECT 
    dep_employee.employee_id, 
    employee.employee_name AS 'Name', 
    department.dep_name AS 'Department', 
    titles.title_name AS 'Title',
    salaries.monthly_salary AS 'Monthly salary in DKK',
    /*Den her bliver roddet, men sjov*/
    (SELECT e.employee_name 
    FROM dep_manager AS dm 
        INNER JOIN employee AS e 
            ON e.employee_id = dm.employee_id 
    WHERE dep_id = department.dep_id) AS 'Manager'
    
FROM dep_employee
    INNER JOIN department ON dep_employee.dep_id = department.dep_id
    INNER JOIN employee ON dep_employee.employee_id = employee.employee_id
    INNER JOIN titles ON employee.title_id = titles.title_id
    INNER JOIN salaries ON salaries.sal_id = titles.sal_id;

/*This view returns information taken from several table about each department*/
CREATE VIEW getDepartmentInfo AS
SELECT 
    department.dep_id AS 'Department ID', 
    department.dep_name AS 'Department name', 
    employee.employee_name AS 'Manager',
    (SELECT count(*) FROM dep_employee WHERE dep_id = department.dep_id) AS 'Employees In Department'
FROM department
    INNER JOIN dep_manager ON dep_manager.dep_id = department.dep_id
    INNER JOIN employee ON employee.employee_id = dep_manager.employee_id;

SELECT * FROM getEmployeeInformation;
SELECT * FROM getDepartmentInfo;

CALL getDepartmentManager(1);
