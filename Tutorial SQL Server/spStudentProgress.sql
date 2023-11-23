CREATE OR ALTER PROCEDURE spStudantProgress(
    @StudentId UNIQUEIDENTIFIER
 )

 AS

SELECT
 [Student].[Name],
 [Course].[Title],
 [StudentCourse].[Progress],
 [StudentCourse].[LastUpdateDate]
FROM
 [StudentCourse]
INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
WHERE
 [Student].[Id] = @StudentId
ORDER BY
 [StudentCourse].[LastUpdateDate] DESC



