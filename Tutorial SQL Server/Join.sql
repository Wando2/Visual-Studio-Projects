USE [Cursos]


SELECT
 [Curso].[Id], [Curso].[Name], [Curso].[CategoriaId] , [Categoria].[Id] AS [Categoria], [Categoria].[Name] AS [CategoriaName]
FROM 
 [Curso]


 INNER JOIN [Categoria] ON [Curso].[CategoriaId] = [Categoria].[Id]

 WHERE [Curso].[Id] = 1

 UNION ALL

    SELECT 
        [Curso].[Id], [Curso].[Name], [Curso].[CategoriaId] , [Categoria].[Id] AS [Categoria], [Categoria].[Name] AS [CategoriaName]
    FROM
        [Curso]
    INNER JOIN [Categoria] ON [Curso].[CategoriaId] = [Categoria].[Id]
    WHERE [Curso].[Id] = 2