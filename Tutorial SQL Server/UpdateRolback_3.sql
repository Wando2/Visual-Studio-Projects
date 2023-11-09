

BEGIN TRANSACTION

UPDATE [Curso] 
SET [Name] = 'Csharp'
WHERE [Id] = 1

ROLLBACK

SELECT TOP (10) 
    [Name],[CategoriaId]
 FROM 
    [Curso]

