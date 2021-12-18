-- Part I
USE Gringotts

-- Problem 1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits

-- Problem 2
SELECT MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits

-- Problem 3
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 4
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- Problem 5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- Problem 7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- Problem 8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge] 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- Problem 9
SELECT AgeGroup, COUNT(*) AS WizardCount FROM
(
	SELECT
		CASE
			WHEN AGE <= 10 THEN '[0-10]'
			WHEN AGE BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN AGE BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN AGE BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN AGE BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN AGE BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup], *
	FROM WizzardDeposits
) AS AgeGroupQuery
GROUP BY AgeGroup

-- Problem 10
SELECT LEFT(FirstName, 1) FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

-- Problem 11
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- Problem 12
SELECT SUM(Difference) AS SumDifference FROM
(
	SELECT FirstName AS [Host Wizard], 
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits
) AS LeadQuery
WHERE [Guest Wizard] IS NOT NULL

-- Part II
USE SoftUni

-- Problem 13
SELECT DepartmentID, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID

-- Problem 14
SELECT DepartmentID, MIN(Salary) AS MinimumSalary 
FROM Employees
WHERE HireDate > '01/01/2000' AND DepartmentID IN (2, 5, 7)
GROUP BY DepartmentID

-- Problem 15
SELECT * INTO EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesWithHighSalaries
GROUP BY DepartmentID

-- Problem 16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- Problem 17
SELECT COUNT(Salary) AS [Count] FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NULL

-- Problem 18
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary FROM
(
	SELECT DepartmentID, Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS SalaryRankQuery
WHERE SalaryRank = 3

-- Problem 19
SELECT TOP(10) e1.FirstName, e1.LastName, e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (
			SELECT AVG(Salary) AS AverageSalary
			FROM Employees AS e2
			WHERE e2.DepartmentID = e1.DepartmentID
			GROUP BY DepartmentID
)
ORDER BY DepartmentID
