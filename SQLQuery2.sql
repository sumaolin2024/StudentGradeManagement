/****** SSMS 的 SelectTopNRows 命令的脚本  ******/
SELECT TOP (1000) [StudentNo]
      ,[Sname]
      ,[Class]
      ,[Chinese]
      ,[Math]
      ,[English]
      ,[Computer]
  FROM [WebDBStudents].[dbo].[Exam]