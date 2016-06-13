CREATE TABLE [dbo].[Qualification]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [LastUpdatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [LastUpdatedBy] NVARCHAR(50) NOT NULL
)

GO

CREATE INDEX [IX_Qualification_Id] ON [dbo].[Qualification] ([Id])

GO

CREATE INDEX [IX_Qualification_Name] ON [dbo].[Qualification] ([Name])
