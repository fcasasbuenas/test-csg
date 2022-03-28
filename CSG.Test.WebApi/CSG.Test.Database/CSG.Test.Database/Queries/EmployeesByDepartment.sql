USE [test-csg]
GO
SELECT d.Name Department, coalesce(ec.amount, 0) Sum
	  FROM [dbo].[Departments] as d
	  left Join (Select count(e.DepartmentId) amount, e.DepartmentId From [dbo].[Employees] e group by DepartmentId) ec 
		on ec.DepartmentId = d.Id 
	ORDER by ec.amount, d.Name asc