CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name])
	VALUES
			(1, 'Sofia'),
			(2, 'Plovdiv'),
			(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
	VALUES
			(1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
			(3, 'Steward', NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions
DROP TABLE Towns

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 90 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Pesho0', '12345', '05.19.2020', 0),
('Pesho1', '12345', '05.19.2020', 1),
('Pesho2', '12345', '05.19.2020', 0),
('Pesho3', '12345', '05.19.2020', 1),
('Pesho4', '12345', '05.19.2020', 1)


ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC071ECA1094]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)


CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
	VALUES
			('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')


INSERT INTO Departments([Name])
	VALUES
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
			('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
			('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
			('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary += Salary * 0.10

SELECT Salary FROM Employees


USE Minions

CREATE TABLE People(
	Id			INT PRIMARY KEY IDENTITY NOT NULL,
	Username	VARCHAR(200) UNIQUE NOT NULL,
	Picture		VARBINARY(2000),
	--CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024),
	Height		DECIMAL(7,2),
	[Weight]	DECIMAL(7,2),
	Gender		VARCHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate	DATE NOT NULL,
	Biography	NVARCHAR(MAX)
)

INSERT INTO People([Username], Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Ivan0', 1.74, 75, 'm','04.25.2007','Ivan want to become CSharp Developer'),
('Ivana1', 1.74, 76, 'f','04.25.2007','Ivan want to become CSharp Developer'),
('Ivan3', 1.74, 77, 'm','04.25.2007','Ivan want to become CSharp Developer'),
('Ivana3', 1.74, 78, 'f','04.25.2007','Ivan want to become CSharp Developer'),
('Ivan5', 1.74, 79, 'm','04.25.2007','Ivan want to become CSharp Developer')


CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
		Id				INT PRIMARY KEY IDENTITY NOT NULL,
		DirectorName	NVARCHAR(30) UNIQUE NOT NULL,
		Notes			NVARCHAR(MAX)
)

CREATE TABLE Genres(
		Id			INT PRIMARY KEY IDENTITY NOT NULL,
		GenreName	NVARCHAR(30) UNIQUE NOT NULL,
		Notes		NVARCHAR(MAX)
)

CREATE TABLE Categories(
		Id				INT PRIMARY KEY IDENTITY NOT NULL,
		CategoryName	NVARCHAR(30) UNIQUE NOT NULL,
		Notes			NVARCHAR(MAX)
)

CREATE TABLE Movies(
		Id				INT PRIMARY KEY IDENTITY NOT NULL,
		Title			NVARCHAR(30) UNIQUE NOT NULL,
		DirectorId		INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
		CopyrightYear	INT NOT NULL,
		[Length]        INT NOT NULL,
		GenreId			INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
		CategoryId		INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
		Rating			INT NOT NULL,
		Notes			NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES
	('John', 'Nothing special at all'),
	('John2', 'Nothing special at all'),
	('John34', 'Nothing special at all'),
	('John4', 'Nothing special at all'),
	('John5', 'Nothing special at all')

INSERT INTO Genres(GenreName, Notes)
VALUES
	('Crime', 'Nothing special at all'),
	('Fantacy', 'Nothing special at all'),
	('Crime2', 'Nothing special at all'),
	('Horror', 'Nothing special at all'),
	('Romantic', 'Nothing special at all')

INSERT INTO Categories(CategoryName, Notes)
VALUES
	('Categoria1', 'Nothing special at all'),
	('Categoria2', 'Nothing special at all'),
	('Categoria3', 'Nothing special at all'),
	('Categoria4', 'Nothing special at all'),
	('Categoria5', 'Nothing special at all')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
	(' King' ,5,1999,78,1,5,10,'otlichen'),
	('RRIRIR',4,2000,90,2,4,9,'otlichen'),
	('plpppo',3,1980,100,3,3,5,'otlichen'),
	('kkiklo',2,1890,20,4,2,10,'iopkll'),
	('ukukkk',1,1990,120,5,1,10,'plpppp')


CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		CategoryName NVARCHAR(50) UNIQUE NOT NULL,
		DailyRate INT NOT NULL,
		WeeklyRate INT, 
		MonthlyRate INT NOT NULL,
		WeekendRate INT
)

CREATE TABLE Cars(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		PlateNumber BIGINT UNIQUE NOT NULL,
		Manufacturer NVARCHAR(20) NOT NULL,
		Model NVARCHAR(20) NOT NULL,
		CarYear INT NOT NULL,
		CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
		Doors INT NOT NULL,
		Picture VARBINARY(2000),
		Condition VARCHAR(20),
		Available BIT NOT NULL,
)

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		Title NVARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Customers(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		DriverLicenceNumber INT NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		[Address] NVARCHAR(20) NOT NULL,
		City NVARCHAR(20) NOT NULL,
		ZIPCode NVARCHAR(10),
		NOTES NVARCHAR(100)
)

CREATE TABLE RentalOrders(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
		CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
		CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
		TankLevel INT NOT NULL,
		KilometrageStart INT NOT NULL,
		KilometrageEnd INT NOT NULL,
		TotalKilometrage INT NOT NULL,
		StartDate DATE NOT NULL,
		EndDate DATE NOT NULL,
		TotalDays INT NOT NULL,
		RateApplied INT,
		TaxRate INT,
		OrderStatus VARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

INSERT INTO Categories(CategoryName, DailyRate, MonthlyRate)
VALUES
('Sedan', 17, 5),
('Sedan3', 10, 6),
('4x4', 11, 3)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
(123458, 'BMW', '330 xd', 1990, 1, 4, 'Good', 1),
(896547, 'VW', 'golf 5', 1993, 1, 5, 'Bad', 0),
(236589, 'Audi', 'a6 ', 1991, 1, 2, 'Good', 1)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Ivan', 'Kurta', 'zaglaviq'),
('Angata', 'Beibe', 'zaglaviq'),
('Malinkov', 'Neta', 'zaglaviq')

INSERT INTO Customers(DriverLicenceNumber, FirstName, [Address], City, ZIPCode)
VALUES
(354128, 'Ivan Kurtacha', 'Hristo smirnenski 3', 'Bracigovo', '4430'),
(374128, 'Angata Kurtacha', 'Hristo smirnenski 2', 'peshtera', '4431'),
(263417, 'Malinkov Kurtacha', 'Hristo smirnenski 1', 'varvara', '4432')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, OrderStatus)
VALUES
(1, 1, 2, 200, 0, 180, 160, '04.24.2004', '04.04.2069', 55555, 'Available'),
(2, 2, 3, 300, 0, 220, 220, '03.21.2004', '03.04.2069', 55555, 'Available'),
(3, 3, 1, 180, 0, 260, 270, '12.12.2004', '12.04.2069', 55555, 'Available')

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		Title NVARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Customers(
		AccountNumber INT PRIMARY KEY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		PhoneNumber INT NOT NULL,
		EmergencyName NVARCHAR(10),
		EmergencyNumber INT,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomStatus(
		RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomTypes(
		RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE BedTypes(
		BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Rooms(
		RoomNumber INT PRIMARY KEY NOT NULL,
		RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
		BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
		Rate INT,
		RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Payments(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		PaymentDate DATE NOT NULL,
		AccountNumber INT NOT NULL,
		FirstDateOccupied DATE,
		LastDateOccupied DATE,
		TotalDays INT,
		AmountCharged INT,
		TaxRate DECIMAL(3,2) NOT NULL,
		TaxAmount INT NOT NULL,
		PaymentTotal INT,
		Notes NVARCHAR(30)
)

CREATE TABLE Occupancies(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		DateOccupied DATE NOT NULL,
		AccountNumber INT NOT NULL,
		RoomNumber INT NOT NULL,
		RateApplied INT NOT NULL,
		PhoneCharge INT,
		Notes NVARCHAR(20)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Ivan', 'Kurtacha', 'Zaglabie'),
('Ivan1', 'Kurtacha', 'Zaglabie'),
('Ivan2', 'Kurtacha', 'Zaglabie')


INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
(1542, 'iVAN', 'kurtacha', 0884552, 'Malinkov', 07744),
(1522, 'iVAN2', 'kurtacha', 0884552, 'Malinkov', 07744),
(1532, 'iVAN3', 'kurtacha', 0884552, 'Malinkov', 07744)

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Available'),
('Busy'),
('busy2')

INSERT INTO RoomTypes(RoomType)
VALUES
('squad'),
('duo'),
('solo')

INSERT INTO BedTypes(BedType)
VALUES
('adult'),
('baby'),
('teen')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(1425, 'squad', 'adult', 'Busy'),
(1456, 'duo', 'baby', 'busy2'),
(14266, 'solo', 'teen', 'Available')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, TaxRate, TaxAmount)
VALUES
(1, '04.18.2020', 23 , 2.58, 550),
(2, '04.18.2020', 44 , 4.58, 533),
(2, '04.18.2020', 12, 1.58, 512)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
(1, '12.24.2020', 17, 1, 85),
(2, '12.24.2020', 77, 2, 65),
(3, '12.24.2020', 177, 4, 12)

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments
