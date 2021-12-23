CREATE DATABASE	CigarShop

USE CigarShop

-- DDL (30 pts)

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Length] INT,
	CHECK (([Length] BETWEEN 10 AND 25) AND [Length] IS NOT NULL),
	RingRange DECIMAL(7, 2),
	CHECK ((RingRange BETWEEN 1.5 AND 7.5) AND RingRange IS NOT NULL)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL,
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
)

CREATE TABLE ClientsCigars
(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
	CONSTRAINT PK_ClientsCigars PRIMARY KEY (ClientId, CigarId)
)

-- DML (10 pts)

-- Problem 2
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

-- Problem 3
UPDATE Cigars
SET PriceForSingleCigar *= 1.20
FROM Cigars c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType = 'Spicy'

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

-- Problem 4
ALTER TABLE Clients
DROP CONSTRAINT [FK__Clients__Address__33D4B598]

ALTER TABLE Clients
ADD CONSTRAINT FK__Clients__Address
FOREIGN KEY ([AddressId])
REFERENCES Addresses(Id)
ON DELETE CASCADE

DELETE Addresses
WHERE Country LIKE 'C%'

-- Querying (40 pts)

-- Problem 5
SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC

-- Problem 6
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength FROM Cigars c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

-- Problem 7
SELECT c.Id, c.FirstName + ' ' + c.LastName AS ClientName, c.Email FROM Clients c
LEFT JOIN ClientsCigars cc ON cc.ClientId = c.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

-- Problem 8
SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL FROM Cigars c
JOIN Sizes AS s ON s.Id = c.SizeId
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR 
c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

-- Problem 9
SELECT c.FirstName + ' ' + c.LastName AS FullName, 
a.Country, a.ZIP, '$' + CAST(MAX(cg.PriceForSingleCigar) AS VARCHAR) AS CigarPrice FROM Clients c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN ClientsCigars cc ON cc.ClientId = c.Id
JOIN Cigars cg ON cg.Id = cc.CigarId
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName ASC

-- Problem 10
SELECT c.LastName, AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange 
FROM Clients c
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS cg ON cg.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = cg.SizeId
GROUP BY c.LastName
ORDER BY CiagrLength DESC

-- Programmability (20 pts)

-- Problem 11
GO

CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT

	SELECT @count = COUNT(cc.CigarId) FROM Clients c
	JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
	WHERE c.FirstName = @name
	GROUP BY c.FirstName, c.LastName

	IF (@count IS NULL)
		RETURN 0

	RETURN @count
END

GO

SELECT dbo.udf_ClientWithCigars('Betty')

-- Problem 12
GO 

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT c.CigarName, '$' + CAST(c.PriceForSingleCigar AS VARCHAR) AS Price,
	t.TasteType, b.BrandName, 
	CAST(s.Length AS VARCHAR) + ' cm', 
	CAST(s.RingRange AS VARCHAR) + ' cm'
	FROM Cigars c
	JOIN Tastes AS t ON t.Id = c.TastId
	JOIN Brands AS b ON b.Id = c.BrandId
	JOIN Sizes AS s ON s.Id = c.SizeId
	WHERE t.TasteType = @taste
	ORDER BY s.Length ASC, s.RingRange DESC
END

EXEC usp_SearchByTaste 'Woody'