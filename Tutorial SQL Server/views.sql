CREATE OR ALTER VIEW vwCourses AS

SELECT TOP (100) 
   [Course].[Id] AS [Course.Id],
   [Course].[Tag] AS [Course.Tag],
   [Course].[Title] AS [Course.Title],
   [Course].[Url] AS [Course.Url],
   [Course].[Summary] AS [Course.Summary],
   [Course].CreateDate AS [Course.CreateDate],
   [Category].[Title] AS [Category.Title],
   [Author].[Name] AS [Author.Name]
 
FROM
[Course]
INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
WHERE
[Active] = 1

/* CREATE OR ALTER VIEW vwCareer AS

SELECT
  [Career].[Id] AS [CareerID],
  [Career].[Title] AS [Title],
  [Career].[Url] AS [Url],
  COUNT([Id]) AS [Courses]
FROM
  [Career]
   INNER JOIN [CareerItem] ON [CareerItem].[CareerID] = [Career].[Id]
GROUP BY
    [Career].[Id],
    [Career].[Title],
    [Career].[Url] */