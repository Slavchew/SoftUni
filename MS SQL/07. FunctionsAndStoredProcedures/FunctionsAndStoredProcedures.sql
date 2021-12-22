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

-- Problem 7
GO

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Result BIT	= 1;
	DECLARE @i INT = 1;

	WHILE (@i <= LEN(@word))
	BEGIN
		IF CHARINDEX(SUBSTRING(@word,@i, 1),@setOfLetters) <= 0
		BEGIN
			SET @Result = 0;
			RETURN @Result;
		END

		SET @i += 1
	END
	RETURN @Result;
END

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves')

-- Problem 8
GO

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

-- Part II
GO

USE Bank

-- Problem 9
GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS FullName 
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName

-- Problem 10
GO

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18,4))
AS
BEGIN
	SELECT ah.FirstName, ah.LastName FROM AccountHolders ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @minBalance
	ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 10000


-- Problem 11
GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @futereValue DECIMAL(18, 4);

	SET @futereValue = @sum * (POWER((1 + @yearlyInterestRate), @years))
	RETURN @futereValue
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- Problem 12
GO

CREATE PROC usp_CalculateFutureValueForAccount(@accountID INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id], ah.FirstName, ah.LastName, a.Balance AS [Current Balance], 
		dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5)
	FROM Accounts a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountID
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

-- Part III
GO

USE Diablo

GO
-- Problem 13
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT g.Name, ug.Cash,
			ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS RowNum
		FROM Games g
		JOIN UsersGames AS ug ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS RowNumQuery
	WHERE RowNum % 2 != 0

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')