


CREATE OR ALTER VIEW vwCursosPorCategoria AS 
    SELECT TOP 10
        [Categoria].[Name] AS [CategoriaName],
        COUNT([Curso].[Id]) AS [CursosTotal]
    FROM
        [Categoria]
    INNER JOIN 
        [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY
        [Categoria].[Name]
    HAVING
        COUNT([Curso].[Id]) > 1;
