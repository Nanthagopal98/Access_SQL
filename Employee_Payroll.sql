--UC-1
CREATE DATABASE Payroll_Service
SELECT * FROM SYS.DATABASES
USE Payroll_Service

--UC-2
CREATE TABLE Employee_Payroll(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NAME VARCHAR(20) NOT NULL,
SALARY FLOAT NOT NUll,
START_DATE DATE NOT NULL
)

--UC-3
INSERT INTO Employee_Payroll VALUES('NANTHAGOPAL',15000,'2022-06-19')
INSERT INTO Employee_Payroll VALUES('ELA',25000,'2022-06-01')
INSERT INTO Employee_Payroll VALUES('THAMARAI',20000,'2018-02-25')
INSERT INTO Employee_Payroll VALUES('SENTHIL',25000,'2021-01-01')
INSERT INTO Employee_Payroll VALUES('PRIYA',10000,'2018-01-01','F')
INSERT INTO Employee_Payroll VALUES('RAMYA',40000,'2019-01-01','F')
INSERT INTO Employee_Payroll VALUES('LALITHA',30000,'2020-01-01','F')

--UC-4
SELECT * FROM Employee_Payroll

--UC-5
SELECT NAME,SALARY FROM Employee_Payroll WHERE NAME='NANTHAGOPAL'
SELECT NAME FROM Employee_Payroll WHERE START_DATE BETWEEN '2021-06-01' AND CURRENT_TIMESTAMP

--UC-6
ALTER TABLE Employee_Payroll ADD GENDER VARCHAR(2) NOT NULL DEFAULT('')
UPDATE Employee_Payroll SET GENDER = 'M' WHERE NAME = 'ELA' 
UPDATE Employee_Payroll SET GENDER = 'M' WHERE NAME = 'NANTHAGOPAL'
UPDATE Employee_Payroll SET GENDER = 'M' WHERE NAME = 'THAMARAI'
UPDATE Employee_Payroll SET GENDER = 'M' WHERE NAME = 'SENTHIL'

--UC-7
SELECT GENDER, SUM(SALARY) AS TOTAL_SALARY FROM Employee_Payroll GROUP BY GENDER
SELECT GENDER, MIN(SALARY) AS TOTAL_SALARY FROM Employee_Payroll GROUP BY GENDER
SELECT GENDER, MAX(SALARY) AS TOTAL_SALARY FROM Employee_Payroll GROUP BY GENDER
SELECT GENDER, AVG(SALARY) AS TOTAL_SALARY FROM Employee_Payroll GROUP BY GENDER
SELECT GENDER, COUNT(GENDER) AS NO_OF_EMPLOYEES FROM Employee_Payroll GROUP BY GENDER

--UC-8
ALTER TABLE Employee_Payroll ADD PHONE INT NOT NULL DEFAULT(0), ADDRESS VARCHAR(50) NOT NULL DEFAULT(''), DEPARTMENT VARCHAR(20) NOT NULL DEFAULT('') 
UPDATE Employee_Payroll SET PHONE = 987456123, ADDRESS = 'NANTHA ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE ID = 1
UPDATE Employee_Payroll SET PHONE = 879456522, ADDRESS = 'ELA ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE NAME = 'ELA'
UPDATE Employee_Payroll SET PHONE = 547992536, ADDRESS = 'THAMARAI ADDRESS', DEPARTMENT = 'MAINTENANCE' WHERE NAME = 'THAMARAI'
UPDATE Employee_Payroll SET PHONE = 879465625, ADDRESS = 'SENTHIL ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE NAME = 'SENTHIL'
UPDATE Employee_Payroll SET PHONE = 987456123, ADDRESS = 'PRIYA ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE NAME = 'PRIYA'
UPDATE Employee_Payroll SET PHONE = 987456123, ADDRESS = 'RAMYA ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE NAME = 'RAMYA'
UPDATE Employee_Payroll SET PHONE = 987456123, ADDRESS = 'LALITHA ADDRESS', DEPARTMENT = 'DEVELOPER' WHERE NAME = 'LALITHA'

--UC-9
ALTER TABLE Employee_Payroll ADD BASIC_PAY FLOAT NOT NULL DEFAULT(0), DEDUCTIONS FLOAT NOT NULL DEFAULT(0),
TAXABLE_PAY FLOAT NOT NULL DEFAULT(0), NET_PAY FLOAT NOT NULL DEFAULT(0)
UPDATE Employee_Payroll SET BASIC_PAY = 25000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 24500 WHERE ID = 1
UPDATE Employee_Payroll SET BASIC_PAY = 25000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 24500 WHERE ID = 2
UPDATE Employee_Payroll SET BASIC_PAY = 20000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 19500 WHERE ID = 3
UPDATE Employee_Payroll SET BASIC_PAY = 25000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 24500 WHERE ID = 4
UPDATE Employee_Payroll SET BASIC_PAY = 10000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 9500 WHERE ID = 6
UPDATE Employee_Payroll SET BASIC_PAY = 40000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 39500 WHERE ID = 7
UPDATE Employee_Payroll SET BASIC_PAY = 30000,DEDUCTIONS = 200,TAXABLE_PAY = 300,NET_PAY = 29500 WHERE ID = 8

--UC-10
INSERT INTO Employee_Payroll VALUES ('TERISSA',50000,'2015-02-03','F',856479985,'TERISSA ADDRESS','SALES AND MARKETING',50000,1000,1000,48000)
--DELETE FROM Employee_Payroll WHERE NAME = 'LALITHA'
--DELETE FROM Employee_Payroll WHERE ID = 10
UPDATE Employee_Payroll SET NAME = 'TERISSA' WHERE ID = 7


--ALTER TABLE Employee_Payroll ALTER COLUMN PHONE FLOAT
--DROP DATABASE

--UC-11
--FOR UC-10- ER DIAGRAM CREATED FOR BELOW TABLES

CREATE TABLE COMPANY_DETAILS(
COMPANY_NAME VARCHAR(30) PRIMARY KEY NOT NULL,
COMPANY_ID INT ,
)
SELECT * FROM COMPANY_DETAILS

INSERT INTO COMPANY_DETAILS VALUES ('ABC Company', 101)
INSERT INTO COMPANY_DETAILS VALUES ('XYZ Company', 102)

CREATE TABLE PAYROLL_DETAILS(
EMPLOYEE_ID INT PRIMARY KEY NOT NULL,
BASIC_PAY INT,
DEDUCTIONS INT,
TAXABLE_PAY INT,
INCOMETAX INT,
NET_PAY INT
) 
SELECT * FROM PAYROLL_DETAILS

INSERT INTO PAYROLL_DETAILS VALUES (1,25000,500,200,300,24000)
INSERT INTO PAYROLL_DETAILS VALUES (2,25000,500,200,300,24000)
INSERT INTO PAYROLL_DETAILS VALUES (3,30000,1000,200,300,28500)
INSERT INTO PAYROLL_DETAILS VALUES (4,30000,1000,200,300,28500)
INSERT INTO PAYROLL_DETAILS VALUES (5,35000,1000,200,300,33500)

CREATE TABLE DEPARTMENT_DETAILS(
DEPARTMENT_ID VARCHAR(10) PRIMARY KEY NOT NULL,
DEPARTMENT_NAME VARCHAR(25)
)
SELECT * FROM DEPARTMENT_DETAILS

INSERT INTO DEPARTMENT_DETAILS VALUES ('01D','DEVELOPER')
INSERT INTO DEPARTMENT_DETAILS VALUES ('01S','SALES')
INSERT INTO DEPARTMENT_DETAILS VALUES ('01M','MARKETING')

CREATE TABLE EMPLOYEE_DEPARTMENT(
EMPLOYEE_ID INT  NOT NULL, 
EMPLOYEE_NAME VARCHAR(25),
DEPARTMENT_ID VARCHAR(10) NOT NULL,
DEPARTMENT_NAME VARCHAR(25)
)

SELECT * FROM EMPLOYEE_DEPARTMENT

INSERT INTO EMPLOYEE_DEPARTMENT VALUES (1,'NANTHAGOPAL','01D','DEVELOPER')
INSERT INTO EMPLOYEE_DEPARTMENT VALUES (2,'ELA','01D','DEVELOPER')
INSERT INTO EMPLOYEE_DEPARTMENT VALUES (3,'RAMYA','01S','SALES')
INSERT INTO EMPLOYEE_DEPARTMENT VALUES (4,'PRIYA','01M','MARKETING')
INSERT INTO EMPLOYEE_DEPARTMENT VALUES (5,'TERISSA','01M','MARKETING')
INSERT INTO EMPLOYEE_DEPARTMENT VALUES (5,'TERISSA','01S','SALES')

CREATE TABLE EMPLOYEE_DETAIL(
EMPLOYEE_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
EMPLOYEE_NAME VARCHAR(25),
GENDER VARCHAR(2),
ADDRESS VARCHAR(50),
PHONE_NUMBER FLOAT,
EMAIL VARCHAR(30)
)
ALTER TABLE EMPLOYEE_DETAIL ADD COMPANY_NAME VARCHAR(20)
ALTER TABLE EMPLOYEE_DETAIL ALTER COLUMN COMPANY_NAME VARCHAR(30)
ALTER TABLE EMPLOYEE_DETAIL ADD JOINING_DATA DATE
SELECT * FROM EMPLOYEE_DETAIL

INSERT INTO EMPLOYEE_DETAIL VALUES ('NANTHAGOPAL','M','NANTHA ADDRESS',9874561230,'nantha@gmail.com','ABC Company')
INSERT INTO EMPLOYEE_DETAIL VALUES ('ELA','M','ELA ADDRESS',7894561230,'ela@gmail.com','ABC Company')
INSERT INTO EMPLOYEE_DETAIL VALUES ('RAMYA','F','RAMYA ADDRESS',8956231470,'ramya@gmail.com','ABC Company')
INSERT INTO EMPLOYEE_DETAIL VALUES ('PRIYA','F','PRIYA ADDRESS',9756324895,'priya@gmail.com','ABC Company')
INSERT INTO EMPLOYEE_DETAIL VALUES ('TERISSA','F','TERISSA ADDRESS',8855226699,'terssia@gmail.com','ABC Company')
UPDATE EMPLOYEE_DETAIL SET JOINING_DATA = '2022-01-05' WHERE EMPLOYEE_ID = 1 
UPDATE EMPLOYEE_DETAIL SET JOINING_DATA = '2018-05-10' WHERE EMPLOYEE_ID = 2
UPDATE EMPLOYEE_DETAIL SET JOINING_DATA = '2021-12-11' WHERE EMPLOYEE_ID = 3 
UPDATE EMPLOYEE_DETAIL SET JOINING_DATA = '2020-04-10' WHERE EMPLOYEE_ID = 4 
UPDATE EMPLOYEE_DETAIL SET JOINING_DATA = '2022-02-14' WHERE EMPLOYEE_ID = 5 
--DELETE FROM EMPLOYEE_DETAIL WHERE EMPLOYEE_NAME = 'TERSSIA'
--UPDATE EMPLOYEE_DETAIL SET EMPLOYEE_NAME = 'TERISSA' WHERE EMPLOYEE_NAME = 'TERSSIA'
--UPDATE EMPLOYEE_DETAIL SET EMPLOYEE_ID = 5 WHERE EMPLOYEE_ID = 6

SELECT * FROM EMPLOYEE_DETAIL

ALTER TABLE EMPLOYEE_DETAIL ADD CONSTRAINT FOREIGN_KEY FOREIGN KEY(COMPANY_NAME) REFERENCES COMPANY_DETAILS(COMPANY_NAME) 
ALTER TABLE EMPLOYEE_DEPARTMENT ADD CONSTRAINT FOREIGN_KEY1 FOREIGN KEY(DEPARTMENT_ID) REFERENCES DEPARTMENT_DETAILS(DEPARTMENT_ID)
ALTER TABLE EMPLOYEE_DEPARTMENT ADD CONSTRAINT FOREIGN_KEY2 FOREIGN KEY(EMPLOYEE_ID) REFERENCES EMPLOYEE_DETAIL(EMPLOYEE_ID)
ALTER TABLE PAYROLL_DETAILS ADD CONSTRAINT FOREIGN_KEY3 FOREIGN KEY(EMPLOYEE_ID) REFERENCES EMPLOYEE_DETAIL(EMPLOYEE_ID)

SELECT GENDER, SUM(BASIC_PAY) AS TOTAL_SALARY FROM EMPLOYEE_DETAIL AS ED INNER JOIN PAYROLL_DETAILS AS PD ON ED.EMPLOYEE_ID = PD.EMPLOYEE_ID GROUP BY GENDER
SELECT GENDER, AVG(BASIC_PAY) AS AVERAGE_SALART FROM EMPLOYEE_DETAIL AS ED INNER JOIN PAYROLL_DETAILS AS PD ON ED.EMPLOYEE_ID = PD.EMPLOYEE_ID GROUP BY GENDER
SELECT GENDER, MIN(BASIC_PAY) AS MINIMUM_SALARY FROM EMPLOYEE_DETAIL AS ED INNER JOIN PAYROLL_DETAILS PD ON ED.EMPLOYEE_ID = PD.EMPLOYEE_ID GROUP BY GENDER
SELECT GENDER, MAX(BASIC_PAY) AS MAX_SALARY FROM EMPLOYEE_DETAIL AS ED INNER JOIN PAYROLL_DETAILS AS PD ON ED.EMPLOYEE_ID = PD.EMPLOYEE_ID GROUP BY GENDER
SELECT GENDER, COUNT(GENDER) FROM EMPLOYEE_DETAIL GROUP BY GENDER

--UC-12

SELECT EMPLOYEE_NAME FROM EMPLOYEE_DETAIL WHERE JOINING_DATA BETWEEN '2020-04-10' AND CURRENT_TIMESTAMP
SELECT COMPANY.COMPANY_NAME,COMPANY.COMPANY_ID,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.GENDER,EMP.ADDRESS,EMP.PHONE_NUMBER,EMP.EMAIL,EMP.JOINING_DATA,DEPT.DEPARTMENT_ID,DEPT.DEPARTMENT_NAME,SALARY.BASIC_PAY,SALARY.NET_PAY
FROM COMPANY_DETAILS COMPANY INNER JOIN EMPLOYEE_DETAIL EMP ON COMPANY.COMPANY_NAME = EMP.COMPANY_NAME INNER JOIN EMPLOYEE_DEPARTMENT DEPT ON DEPT.EMPLOYEE_ID = EMP.EMPLOYEE_ID INNER JOIN PAYROLL_DETAILS SALARY ON SALARY.EMPLOYEE_ID = EMP.EMPLOYEE_ID

GO
CREATE PROCEDURE CONNECTIVITY
AS 
SELECT * FROM COMPANY_DETAILS