USE [Curso]

DROP TABLE [Aluno]
DROP TABLE [Categoria]
DROP TABLE [Curso]
DROP TABLE [ProgessoCurso]


CREATE TABLE [Aluno](
    [AlunoId] [int] IDENTITY(1,1) ,
    [Nome] [varchar](50) NOT NULL,
    [Nascimento] DATETIME,
    [Active] [bit] NOT NULL DEFAULT(0),
    

    CONSTRAINT [PK_Aluno] PRIMARY KEY ([AlunoId])
)

CREATE INDEX [IX_Aluno_Nome] ON [Aluno]([Nome])

CREATE TABLE [Categoria](
    [Id] [int] IDENTITY(1,1),
    [Nome] [varchar](50) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])


)

CREATE TABLE [Curso](
    [CursoId] [int] IDENTITY,
    [Nome] [varchar](50) NOT NULL,
    [CategoriaId] [int] NOT NULL,
  
    CONSTRAINT [PK_Curso] PRIMARY KEY ([CursoId]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria]([Id])
)

CREATE TABLE [ProgessoCurso](
    [AlunoId] [int] NOT NULL,
    [CursoId] [int] NOT NULL,
    [Progresso] [int] NOT NULL DEFAULT(0),
    [UltimaAtualizacao] [datetime] NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_ProgessoCurso] PRIMARY KEY ([AlunoId], [CursoId])
)

