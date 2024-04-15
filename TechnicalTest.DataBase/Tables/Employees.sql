CREATE TABLE [dbo].[Employees]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DocumentTypeId] TINYINT NOT NULL, 
    [DocumentNumber] VARCHAR(15) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Surname] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(100) NOT NULL, 
    [LeaderId] UNIQUEIDENTIFIER NULL, 
    [AreaId] TINYINT NOT NULL, 
    [RolId] TINYINT NOT NULL, 
    CONSTRAINT [FK_Employees_DocumentTypes] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes]([Id]), 
    CONSTRAINT [FK_Employees_Employees] FOREIGN KEY ([LeaderId]) REFERENCES [Employees]([Id]),
    CONSTRAINT [FK_Employees_Areas] FOREIGN KEY ([AreaId]) REFERENCES [Areas]([Id]),
    CONSTRAINT [FK_Employees_Roles] FOREIGN KEY ([RolId]) REFERENCES [Roles]([Id]), 
    CONSTRAINT [UQ_Employees_Email] UNIQUE([Email])
)