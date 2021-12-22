-- Problem 1
CREATE TABLE Logs
(
	LogID INT PRIMARY KEY IDENTITY NOT NULL,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)
)

GO

CREATE TRIGGER tr_AccountChanges ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @accountId INT;
	DECLARE @oldSum DECIMAL(15, 2);
	DECLARE @newSum DECIMAL(15, 2);

	SET @accountId = (SELECT i.Id
		            FROM inserted AS i)

	SET @oldSum = (SELECT d.Balance
		         FROM deleted AS d)

	SET @newSum = (SELECT i.Balance
		         FROM inserted AS i)

	INSERT INTO Logs(AccountId, OldSum, NewSum)
	VALUES		(@accountId, @oldSum, @newSum)
END

UPDATE Accounts
SET Balance += 50
WHERE Id = 1

-- Problem 2
CREATE TABLE NotificationEmails
(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT REFERENCES Accounts(Id) NOT NULL,
	[Subject] NVARCHAR(MAX),		
	Body NVARCHAR(MAX)
)

GO

CREATE TRIGGER tr_CreateEmail ON Logs FOR INSERT
AS
BEGIN
	DECLARE @recipient INT;
	DECLARE @subject VARCHAR(200);
	DECLARE @oldBalance DECIMAL(15, 2);
	DECLARE @newBalance DECIMAL(15, 2);
	DECLARE @body VARCHAR(200);

	SET @recipient = (SELECT i.AccountId FROM inserted AS i)
	SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(MAX))
	SET @oldBalance = (SELECT i.OldSum FROM inserted AS i)
	SET @newBalance = (SELECT i.NewSum FROM inserted AS i)
	SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(MAX)) 
	            + ' your balance was changed from ' + CAST(@oldBalance AS VARCHAR(MAX))
		    + ' to ' + CAST(@newBalance AS VARCHAR(MAX))

	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	VALUES	    (@recipient, @subject, @body)
END

UPDATE Accounts
SET Balance += 50
WHERE Id = 1

-- Problem 3
CREATE PROC usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts AS a 
		WHERE a.Id = @AccountId) OR @accountId IS NULL)
	BEGIN 
		ROLLBACK
		RAISERROR('Invalid accountId', 16, 2)
		RETURN
	END

	UPDATE Accounts
	   SET Balance += @moneyAmount
	 WHERE Id = @accountId
COMMIT

EXEC usp_DepositMoney 2, 500

-- Problem 4
GO

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts AS a 
		WHERE a.Id = @AccountId) OR @accountId IS NULL)
	BEGIN 
		ROLLBACK
		RAISERROR('Invalid accountId', 16, 2)
		RETURN
	END

	UPDATE Accounts
	   SET Balance -= @moneyAmount
	 WHERE Id = @accountId
COMMIT

EXEC usp_WithdrawMoney 2, 500

-- Problem 5
GO

CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	IF (@amount < 0 OR @amount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT * FROM Accounts a
		WHERE a.Id = @senderId) OR @senderId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid senderId', 16, 2)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT * FROM Accounts a
		WHERE a.Id = @receiverId) OR @receiverId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid receiverId', 16, 3)
		RETURN
	END

	EXEC dbo.usp_DepositMoney @receiverId, @amount
	EXEC dbo.usp_WithdrawMoney @senderId, @amount

COMMIT

EXEC usp_TransferMoney 1, 2, 100


-- Part II
GO
USE SoftUni


-- Problem 8
GO

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	DECLARE @projectsCount INT;

	SET @projectsCount = (SELECT COUNT(ep.EmployeeID)
				FROM EmployeesProjects AS ep
                               WHERE ep.EmployeeID = @emloyeeId)

	IF (@projectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	VALUES	    (@emloyeeId, @projectID)
COMMIT

-- Problem 9
CREATE TABLE Deleted_Employees
(
	EmployeeID INT IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT REFERENCES Departments(DepartmentId) NOT NULL,
	Salary MONEY NOT NULL,
)

GO

CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	     SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary 
	       FROM deleted AS d
END