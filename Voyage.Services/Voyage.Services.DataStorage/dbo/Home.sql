CREATE TABLE [dbo].[Home]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [LastUpdatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [LastUpdatedBy] NVARCHAR(50) NOT NULL
)

GO

CREATE INDEX [IX_Home_Id] ON [dbo].[Home] ([Id])
