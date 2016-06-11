CREATE TABLE [dbo].[StaffMember]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Forename] VARCHAR(50) NOT NULL, 
    [Surname] VARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [HomeId] INT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [LastUpdatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [LastUpdatedBy] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_StaffMember_Home] FOREIGN KEY ([HomeId]) REFERENCES [Home]([Id])
)

GO

CREATE INDEX [IX_StaffMember_Surname] ON [dbo].[StaffMember] ([Surname])

GO

CREATE INDEX [IX_StaffMember_Id] ON [dbo].[StaffMember] ([Id])
