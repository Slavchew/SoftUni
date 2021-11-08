USE SoftUni

-- Ex. 2
SELECT * FROM Departments

-- Ex. 3
SELECT [Name] FROM Departments

-- Ex. 4
SELECT FirstName, LastName, Salary FROM Employees

-- Ex. 5
SELECT FirstName, MiddleName, LastName FROM Employees

-- Ex. 6
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
	FROM Employees

-- Ex. 7
SELECT DISTINCT Salary 
	FROM Employees

-- Ex. 8
SELECT * 
	FROM Employees
	WHERE JobTitle = 'Sales Representative'

-- Ex. 9
SELECT FirstName, LastName, JobTitle 
	FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000

-- Ex. 10
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)

-- Ex. 11
SELECT FirstName, LastName 
	FROM Employees
	WHERE ManagerID IS NULL

-- Ex. 12
SELECT FirstName, LastName, Salary 
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

-- Ex. 13
SELECT TOP(5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC

-- Ex. 14
SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID != 4

-- Ex. 15
SELECT * 
	FROM Employees
	ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC

-- Ex. 16
CREATE VIEW V_EmployeesSalaries AS
	(SELECT FirstName, LastName, Salary
	FROM Employees)

-- Ex. 17
CREATE VIEW V_EmployeeNameJobTitle 
AS
(SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS [Full Name],
	JobTitle
	FROM Employees)

-- Ex. 18
SELECT DISTINCT JobTitle FROM Employees

-- Ex. 19
SELECT TOP(10) *
	FROM Projects
	ORDER BY StartDate, [Name]

-- Ex. 20
SELECT TOP(7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC

-- Ex. 21
UPDATE Employees
	SET
	Salary += Salary * 0.12
	WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary
	FROM Employees

-- Part II
USE Geography

-- Ex. 22
SELECT PeakName 
	FROM Peaks
	ORDER BY PeakName ASC

-- Ex. 23
SELECT TOP(30) CountryName, [Population]
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY Population DESC, CountryName ASC

-- Ex. 24
SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS Currency
FROM Countries
ORDER BY CountryName ASC

-- Part III
USE Diablo

-- Ex. 25
SELECT [Name] 
	FROM Characters
	ORDER BY [Name] ASC



