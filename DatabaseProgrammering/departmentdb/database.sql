DROP DATABASE IF EXISTS departmentdb;
CREATE DATABASE departmentdb;

USE departmentdb;
CREATE TABLE salaries(
    sal_id int AUTO_INCREMENT,
    monthly_salary double,
    PRIMARY KEY (sal_id)
);

CREATE TABLE titles(
    title_id int AUTO_INCREMENT,
    sal_id int,
    title_name varchar(32),
    PRIMARY KEY (title_id),
    FOREIGN KEY (sal_id) 
        REFERENCES salaries(sal_id)
);
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


