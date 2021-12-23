CREATE DATABASE Airport

USE Airport

-- DDL (30 pts)
CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT CHECK (Age BETWEEN 21 AND 61) NOT NULL,
	Rating FLOAT CHECK (Rating BETWEEN 0.00 AND 10.00)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeID INT REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL,
	PilotId INT NOT NULL,
	CONSTRAINT PK_PilotsAircraft PRIMARY KEY (AircraftId, PilotId),
	CONSTRAINT FK_PilotsAircraft_Aircraft FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id),
	CONSTRAINT FK_PilotsAircraft_Pilot FOREIGN KEY (PilotId) REFERENCES Pilots(Id)
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AirportId INT REFERENCES Airports(Id) NOT NULL,
	Start DATETIME NOT NULL,
	AircraftId INT REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18, 2) DEFAULT 15 NOT NULL
)


-- DML (10 pts)

-- Problem 2
INSERT INTO Passengers(FullName, Email)
SELECT FirstName + ' ' + LastName AS FullName,
FirstName + LastName + '@gmail.com' AS Email
FROM Pilots
WHERE Id BETWEEN 5 AND 15;

-- Problem 3
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND 
(FlightHours IS NULL OR FlightHours <= 100) AND
(Year >= 2013)

-- Problem 4
DELETE Passengers
WHERE LEN(FullName) <= 10

-- Querying (40 pts)

-- Problem 5
SELECT Manufacturer, Model, FlightHours, Condition FROM Aircraft
ORDER BY FlightHours DESC

-- Problem 6
SELECT p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours 
FROM Aircraft AS a
JOIN PilotsAircraft AS pa ON pa.AircraftId = a.Id
JOIN Pilots AS p ON p.Id = pa.PilotId
WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
ORDER BY a.FlightHours DESC, p.FirstName ASC


-- Problem 7
SELECT TOP(20) d.Id, d.Start, p.FullName, a.AirportName, d.TicketPrice 
FROM FlightDestinations AS d
JOIN Passengers AS p ON p.Id = d.PassengerId
JOIN Airports AS a ON a.Id = d.AirportId
WHERE DAY(d.Start) % 2 = 0
ORDER BY TicketPrice DESC, a.AirportName ASC

-- Problem 8
SELECT d.AircraftId, a.Manufacturer, 
(SELECT FlightHours FROM Aircraft WHERE Id = d.AircraftId) AS FlightHours, 
COUNT(d.Id) AS FlightDestinationsCount,
ROUND(AVG(d.TicketPrice), 2) AS AvgPrice
FROM FlightDestinations d
JOIN Aircraft AS a ON a.Id = d.AircraftId
GROUP BY d.AircraftId, a.Manufacturer
HAVING COUNT(d.Id) >= 2
ORDER BY FlightDestinationsCount DESC, d.AircraftId ASC

-- Problem 9
SELECT p.FullName, 
COUNT(d.AircraftId) AS CountOfAircraft, 
SUM(d.TicketPrice) AS TotalPayed
FROM FlightDestinations d
JOIN Passengers AS p ON p.Id = d.PassengerId
GROUP BY p.FullName
HAVING COUNT(d.AircraftId) > 1 AND SUBSTRING(p.FullName, 2, 1) = 'a'
ORDER BY p.FullName

-- Problem 10
SELECT a.AirportName, d.Start AS DayTime, d.TicketPrice, p.FullName, ac.Manufacturer, ac.Model
FROM FlightDestinations d
JOIN Airports AS a ON a.Id = d.AirportId
JOIN Passengers AS p ON p.Id = d.PassengerId
JOIN Aircraft AS ac ON ac.Id = d.AircraftId
WHERE (DATEPART(HOUR, d.Start) BETWEEN 6 AND 20) AND d.TicketPrice > 2500
ORDER BY ac.Model

-- Programmability (20 pts)

-- Problem 11
GO

CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT

	SELECT @count = COUNT(d.Id) FROM FlightDestinations d
	JOIN Passengers AS p ON p.Id = d.PassengerId
	WHERE p.Email = @email
	GROUP BY p.FullName

	IF (@count IS NULL)
		RETURN 0

	RETURN @count
END

GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

-- Problem 12

GO

CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	SELECT a.AirportName, p.FullName,
		CASE
			WHEN d.TicketPrice <= 400 THEN 'Low'
			WHEN d.TicketPrice <= 1500 THEN 'Medium'
			ELSE 'High'
		END AS LevelOfTickerPrice,
	ac.Manufacturer, ac.Condition, act.TypeName
	FROM Airports a
	JOIN FlightDestinations AS d ON d.AirportId = a.Id
	JOIN Passengers AS p ON p.Id = d.PassengerId
	JOIN Aircraft AS ac ON ac.Id = d.AircraftId
	JOIN AircraftTypes AS act ON act.Id = ac.TypeID
	WHERE a.AirportName = @airportName
	ORDER BY ac.Manufacturer, p.FullName
END