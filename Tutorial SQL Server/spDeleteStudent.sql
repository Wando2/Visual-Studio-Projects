CREATE OR ALTER PROCEDURE deleteStudent(
    @StudentId UNIQUEIDENTIFIER
 )
 
 AS

 BEGIN TRANSACTION
 
    DELETE FROM [StudentCourse] WHERE StudentId = @StudentId

    DELETE FROM Student WHERE Id = @StudentId

COMMIT TRANSACTION    

