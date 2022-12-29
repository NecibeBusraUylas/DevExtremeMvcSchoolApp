CREATE TABLE [dbo].[Student] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Surname] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Instructor] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Surname] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Course] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [InstrutorId] INT NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([InstrutorId]) REFERENCES [dbo].[Instructor] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[CourseEnrollment] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [StudentId] INT NOT NULL,
    [CourseId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([StudentId] ASC, [CourseId] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id]) ON DELETE CASCADE
);


INSERT INTO Student VALUES ('Can','Çakır');
INSERT INTO Student VALUES ('İpek','Kaya');
INSERT INTO Student VALUES ('Uğur','Yılmaz');
INSERT INTO Student VALUES ('Ece','Demir');
INSERT INTO Student VALUES ('Ali','Kahraman');

INSERT INTO Instructor VALUES ('Ayşe','Aslan');
INSERT INTO Instructor VALUES ('Ahmet','Yiğit');
INSERT INTO Instructor VALUES ('Elif','Işık');
INSERT INTO Instructor VALUES ('Demir','Tekin');
INSERT INTO Instructor VALUES ('Canan','Şen');

INSERT INTO Course VALUES (1,'C#');
INSERT INTO Course VALUES (2,'C++');
INSERT INTO Course VALUES (3,'C');
INSERT INTO Course VALUES (4,'PYTHON');
INSERT INTO Course VALUES (5,'JAVA');

INSERT INTO CourseEnrollment VALUES (1,2);
INSERT INTO CourseEnrollment VALUES (2,5);
INSERT INTO CourseEnrollment VALUES (3,4);
INSERT INTO CourseEnrollment VALUES (4,1);
INSERT INTO CourseEnrollment VALUES (5,3);