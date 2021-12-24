CREATE DATABASE Bitbucket

USE Bitbucket

-- DDL (30 pts)

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Message VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(7,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

-- DML (10 pts)

-- Problem 2
INSERT INTO Files(Name, Size, ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

-- Problem 3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

-- Problem 4
DELETE RepositoriesContributors
WHERE RepositoryId = 3

DELETE Issues
WHERE RepositoryId = 3

-- Querying (40 pts)

-- Problem 5
SELECT Id, Message, RepositoryId, ContributorId FROM Commits
ORDER BY Id ASC, Message ASC, RepositoryId ASC, ContributorId ASC

-- Problem 6
SELECT Id, Name, Size FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

-- Problem 7
SELECT i.Id, u.Username + ' : ' + i.Title AS IssueAssignee FROM Issues i
JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

-- Problem 8
SELECT p.Id, p.Name, CAST(p.Size AS VARCHAR) + 'KB' AS Size FROM Files AS f
FULL OUTER JOIN Files AS p ON p.Id = f.ParentId
WHERE f.Id IS NULL
ORDER BY Id, Name, Size DESC

-- Problem 9
SELECT TOP(5) r.Id ,r.Name, COUNT(*) AS Commits FROM Repositories r
LEFT JOIN Commits AS c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name

-- Problem 10
SELECT u.Username, AVG(f.Size) AS Size FROM Users u
JOIN Commits AS c ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username

-- Programmability (20 pts)

-- Problem 11
GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT

	SELECT @count = COUNT(*) FROM Users u
	JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username
	GROUP BY u.Id

	IF (@count IS NULL)
		RETURN 0

	RETURN @count
END

GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

-- Problem 12
GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(50))
AS
BEGIN
	SELECT Id, Name, CAST(Size AS VARCHAR) + 'KB' AS Size FROM Files
	WHERE Name LIKE '%' + @fileExtension
	ORDER BY Id, Name, Size DESC
END

EXEC usp_SearchForFiles 'txt'

