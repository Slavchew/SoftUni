-- Part I
USE SoftUni

-- Problem 1
SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY AddressID

-- Problem 2
SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY FirstName, LastName

-- Problem 3
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- Problem 4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

-- Problem 5
SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

-- Problem 6
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d ON E.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- Problem 7
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08.13.2002'
ORDER BY e.EmployeeID

-- Problem 8
SELECT e.EmployeeID, e.FirstName,
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
	END AS ProjectName
FROM Employees e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- Problem 9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName FROM Employees e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

-- Problem 10
SELECT TOP(50) e.EmployeeID, 
(e.FirstName + ' ' + e.LastName) AS EmployeeName,
(m.FirstName + ' ' + m.LastName) AS ManagerName,
d.Name AS DepartmentName
FROM Employees e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11
SELECT MIN(a.AverageSalary) AS MinAverageSalary
FROM 
(
	SELECT e.DepartmentID, 
	AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS a

-- Or
SELECT TOP(1)
AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary


-- Part II
USE Geography

-- Problem 12
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- Problem 13
SELECT CountryCode, COUNT(MountainId) AS MountainRanges
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY CountryCode

-- Problem 14
SELECT TOP(5) c.CountryName, r.RiverName 
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- Problem 15
SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage FROM
(
	SELECT ContinentCode, CurrencyCode, CurrencyCount, 
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
	(
		SELECT ContinentCode, CurrencyCode, 
		COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS CurrencyCountQuery
	WHERE CurrencyCount > 1
) AS CurrencyRankingQuery
WHERE CurrencyRank = 1


-- Problem 16
SELECT COUNT(*) AS [Count] 
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE mc.MountainId IS NULL

-- Problem 17
SELECT TOP(5) CountryName, 
MAX(p.Elevation) AS [HighestPeakElevation], 
MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, LongestRiverLength DESC, c.CountryName

-- Problem 18
SELECT TOP(5) Country,
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	END AS [Highest Peak Elevation], 
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	END AS [Mountain]
FROM
(
	SELECT *,
	DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS PeakRank
	FROM
	(
		SELECT c.CountryName AS Country, 
		p.PeakName, p.Elevation, m.MountainRange
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	) AS FullInformationQuery
) AS PeakRankingQuery
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Elevation]