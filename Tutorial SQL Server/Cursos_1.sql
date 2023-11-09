CREATE DATABASE [Cursos]
GO

USE [Cursos]

CREATE TABLE [Categoria](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)

CREATE TABLE [Curso](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [CategoriaId] [int] NOT NULL,
    [Name] [nvarchar](50) NOT NULL

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id])
    FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])
)
