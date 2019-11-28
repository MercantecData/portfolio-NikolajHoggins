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

CREATE TABLE deb_manager(
    manager_id int AUTO_INCREMENT,
    employee_id int,
    dep_id int,
    PRIMARY KEY (manager_id),
    FOREIGN KEY (employee_id) REFERENCES employee(employee_id),
    FOREIGN KEY (dep_id) REFERENCES department(dep_id)
);

CREATE TABLE dep_employee(
    d_employee_id int AUTO_INCREMENT,
    employee_id int,
    dep_id int,
    PRIMARY KEY (d_employee_id),
    FOREIGN KEY (employee_id) REFERENCES employee(employee_id),
    FOREIGN KEY (dep_id) REFERENCES department(dep_id)
);

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
('Lead Dev', 4),
('Programmer', 3),
('Programmer Apprentience', 1),
('Janitor', 2),
('Manager', 5),
('It-supporter', 2);

INSERT INTO employee(title_id, employee_name, employee_age, employee_address, employed_years) VALUES
((SELECT title_id FROM titles WHERE title_name = 'Lead Dev'), 'Rasmus Kjeldsen', 26, 'Normansvej 1, 8900, Randers', 8),
((SELECT title_id FROM titles WHERE title_name = 'Programmer Apprentience'), 'Nikolaj Hoggins', 17, 'Hans Tausens Vej 22, 8800, Viborg', 1),
(5, 'Mike Møller', 29, 'Vejnavn 14, 8900, Randers', 5),
(4, 'Per Persen', 54, 'Brovej 43, 8900, Randers', 17),
(2, 'Progra Møhr', 22, 'Kodevej 7, 1113, København', 3);


SELECT * FROM department;
SELECT * FROM salaries;
SELECT * FROM titles;
SELECT * FROM employee;