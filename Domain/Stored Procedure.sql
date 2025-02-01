USE [Employee_Mangement_System_DB2]
GO
DROP PROCEDURE IF EXISTS [dbo].[GetDepartmentNames];
DROP PROCEDURE IF EXISTS [dbo].[GetEmployeeDetails];
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[GetDepartmentNames]
AS
BEGIN
    -- Select only the DepartmentId and DepartmentName columns
    SELECT Id, DepartmentName
    FROM Departments
END
GO
CREATE or ALTER PROCEDURE GetEmployeeDetails
AS
BEGIN
    SELECT
        e.Id AS Id,
        e.Name AS EmployeeName,
        e.DepartmentId AS DepartmentId,
        d.DepartmentName AS DepartmentName,
        e.Position AS Position,
        e.Status AS Status,
        e.Deleted AS Deleted
    FROM
        Employees e
    INNER JOIN
        Departments d ON e.DepartmentId = d.Id
    --WHERE
    --    e.Deleted = 0; -- Exclude soft-deleted employees
END
GO

CREATE or ALTER PROCEDURE GetDepartmentManagementDetails
AS
BEGIN
    SELECT 
        E.Id AS EmployeeId,
        E.Name AS EmployeeName,
        E.DepartmentId,
        D.DepartmentName,
        E.Position,
        E.Status
    FROM 
        Employees E
    INNER JOIN 
        Departments D ON E.DepartmentId = D.Id
    ORDER BY 
        E.DepartmentId;
END
GO
CREATE Or ALTER PROCEDURE GetPerformanceReviewDetails
AS
BEGIN
    SELECT 
        PR.Id AS PerformanceReviewId,
        E.Name AS EmployeeName,
        E.Id AS EmployeeId,
        PR.ReviewScore,
        PR.ReviewNotes,
        E.DepartmentId,
        D.DepartmentName
    FROM 
        PerformanceReview PR
    INNER JOIN 
        Employee E ON PR.EmployeeId = E.Id
    INNER JOIN 
        DepartmentManagement D ON E.DepartmentId = D.Id
    ORDER BY 
        PR.ReviewDate DESC;  -- Optional: Sort by review date, or modify as needed
END
GO

CREATE OR ALTER PROCEDURE GetAveragePerformanceScoreByDepartment
AS
BEGIN
    SELECT 
        E.DepartmentId, 
        D.DepartmentName,
        CAST(AVG(PR.ReviewScore) AS DECIMAL(10, 2)) AS AveragePerformanceScore
    FROM 
        PerformanceReviews PR
    INNER JOIN 
        Employees E ON PR.EmployeeId = E.Id
    INNER JOIN 
        Departments D ON E.DepartmentId = D.Id
    WHERE 
        E.Deleted = 0  -- Optional: Exclude deleted employees
    GROUP BY 
        E.DepartmentId, D.DepartmentName
    ORDER BY 
        D.DepartmentName;  -- Optional: Sort by department name, or adjust as needed
END
GO