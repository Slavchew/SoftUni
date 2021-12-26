-- Problem 1
CREATE DATABASE MinionsDB

USE MinionsDB

CREATE TABLE Countries 
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50)
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50), 
	CountryCode INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Minions
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30), 
	Age INT, 
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE EvilnessFactors
(
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50)
)

CREATE TABLE Villains 
(
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50), 
	EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id)
)

CREATE TABLE MinionsVillains 
(
	MinionId INT FOREIGN KEY REFERENCES Minions(Id),
	VillainId INT FOREIGN KEY REFERENCES Villains(Id),
	CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId)
)
--03
INSERT INTO Countries ([Name]) 
VALUES 
('Bulgaria'),
('England'),
('Cyprus'),
('Germany'),
('Norway')

INSERT INTO Towns ([Name], CountryCode) 
VALUES 
('Plovdiv', 1),
('Varna', 1),
('Burgas', 1),
('Sofia', 1),
('London', 2),
('Southampton', 2),
('Bath', 2),
('Liverpool', 2),
('Berlin', 3),
('Frankfurt', 3),
('Oslo', 4)

INSERT INTO Minions (Name,Age, TownId) 
VALUES('Bob', 42, 3),
('Kevin', 1, 1),
('Bob ', 32, 6),
('Simon', 45, 3),
('Cathleen', 11, 2),
('Carry ', 50, 10),
('Becky', 125, 5),
('Mars', 21, 1),
('Misho', 5, 10),
('Zoe', 125, 5),
('Json', 21, 1)

INSERT INTO EvilnessFactors (Name) 
VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

INSERT INTO Villains (Name, EvilnessFactorId) 
VALUES 
('Gru',2),
('Victor',1),
('Jilly',3),
('Miro',4),
('Rosen',5),
('Dimityr',1),
('Dobromir',2)

INSERT INTO MinionsVillains (MinionId, VillainId) 
VALUES 
(4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),
(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)


-- Problem 2
SELECT v.Name, COUNT(m.ID) AS Count FROM Villains v
JOIN MinionsVillains mv ON mv.VillainId = v.Id
JOIN Minions m ON mv.MinionId = m.Id
GROUP BY v.Name
HAVING COUNT(m.Id) > 3
ORDER BY COUNT(m.ID) DESC

-- Problem 3
SELECT Name FROM Villains
WHERE Id = @Id

SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNumber,
m.Name, m.Age FROM Villains v
JOIN MinionsVillains mv ON mv.VillainId = v.Id
JOIN Minions m ON mv.MinionId = m.Id
WHERE v.Id = @Id
ORDER BY m.Name


-- Problem 4
SELECT Id FROM Towns
WHERE Name = @townName

INSERT INTO Towns(Name, CountryCode)
VALUES
(@townName, 1)

SELECT Id FROM Villains
WHERE Name = @villainName

INSERT INTO Villains(Name, EvilnessFactorId)
VALUES
(@villainName, 4)

SELECT Id FROM EvilnessFactors
WHERE Name = 'Evil'

INSERT INTO Minions(Name, Age, TownId)
VALUES
(@minionName, @minionAge, @townId)

SELECT Id FROM Minions
WHERE Name = @minionName

INSERT INTO MinionsVillains(MinionId, VillainId)
VALUES
(@minionId, @villainId)

-- Problem 5

SELECT Id FROM Countries
WHERE Name = @countryName

UPDATE Towns
SET Name = UPPER(Name)
WHERE CountryCode = @countryId

SELECT Name FROM Towns
WHERE CountryCode = 1


-- Problem 6
SELECT Name FROM Villains
WHERE Id = @villainId

DELETE FROM Villains
WHERE Id = @villainId

DELETE FROM MinionsVillains
WHERE VillainId = 9


-- Problem 7

SELECT Name, Age FROM Minions
WHERE Id = @id

-- Problem 8
UPDATE Minions
SET Age += 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name) - 1)
WHERE Id = 1

UPDATE Minions
SET Name = LOWER(Name)
WHERE Id = 1

SELECT Name, Age FROM Minions

-- Problem 9
GO

CREATE PROC usp_GetOlder(@minionID INT)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE Id = @minionID
END

EXEC usp_GetOlder 2

SELECT Name, Age FROM Minions
WHERE Id = @minionID
