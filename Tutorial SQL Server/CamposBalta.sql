
USE [balta]

CREATE TABLE [Student](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Phone] NVARCHAR(15) NOT NULL,
    [Document] NVARCHAR(20) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT GETDATE()

    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Author](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Title] NVARCHAR(100) NOT NULL,
    [Image] NVARCHAR(100) NOT NULL,
    [Bio] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(400) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Type] TINYINT NOT NULL,

    CONSTRAINT [PK_Author] PRIMARY KEY ([Id])
)

GO

CREATE TABLE[Career](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(100) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [DuratonInMinutes] INT NOT NULL,
    [Active] BIT NOT NULL,
    [Featured] BIT NOT NULL,
    [Tags] NVARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Career] PRIMARY KEY ([Id])
    
)

GO

CREATE TABLE [Category](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(100) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Order] INT NOT NULL,
    [Featured] BIT NOT NULL,
    [Description] TEXT NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)

GO

CREATE TABLE [Course](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(100) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [DurationInMinutes] INT NOT NULL,
    [Level] TINYINT NOT NULL,
    [CreateDate] DATETIME NOT NULL,
    [LastUpdateDate] DATETIME NOT NULL,
    [Featured] BIT NOT NULL,
    [Free] BIT NOT NULL,
    [Active] BIT NOT NULL,
    [AuthorId] UNIQUEIDENTIFIER NOT NULL,
    [CategoryId] UNIQUEIDENTIFIER NOT NULL,
    [Tags] NVARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Course] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Course_Author_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Course_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION
)

GO

USE [balta]

CREATE TABLE[CareerItem](
    [Title] NVARCHAR(100) NOT NULL,
    [CareerId] UNIQUEIDENTIFIER NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [Order] INT NOT NULL,

    CONSTRAINT [PK_CareerItem] PRIMARY KEY ([CareerId], [CourseId]),
    CONSTRAINT [FK_CareerItem_Career_CareerId] FOREIGN KEY ([CareerId]) REFERENCES [Career] ([Id]),
    CONSTRAINT [FK_CareerItem_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id])

    
)
GO

CREATE TABLE[StudentCourse](
    [StudentId] INT NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [Favorite] BIT NOT NULL,
    [Progress] TINYINT NOT NULL,
    [StartDate] DATETIME NOT NULL,
    [LastUpdateDate] DATETIME NOT NULL,
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([StudentId], [CourseId]),
    CONSTRAINT [FK_StudentCourse_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id]),
    CONSTRAINT [FK_StudentCourse_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id])
)

GO

