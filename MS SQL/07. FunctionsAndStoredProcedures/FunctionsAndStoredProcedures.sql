-- Part I
USE SoftUni


-- Problem 1
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] 
	FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

-- Problem 2
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] 
	FROM Employees
	WHERE Salary >= @Number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- Problem 3
GO

CREATE PROC usp_GetTownsStartingWith(@String NVARCHAR(50))
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE (@String + '%')
END

EXEC usp_GetTownsStartingWith 'B'

-- Problem 4
GO

CREATE PROC usp_GetEmployeesFromTown(@Town NVARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM Employees e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @Town
END

EXEC usp_GetEmployeesFromTown 'Sofia'

-- Problem 5
GO

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)
	IF (@Salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF(@Salary <= 50000)
		SET @salaryLevel = 'Average'
	ELSE
		SET @salaryLevel = 'High'
	RETURN @salaryLevel
END

SELECT dbo.ufn_GetSalaryLevel(60000)

-- Problem 6
GO

CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel NVARCHAR(7))
AS
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM Employees e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'High'

-- Problem 8
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Result	
END
