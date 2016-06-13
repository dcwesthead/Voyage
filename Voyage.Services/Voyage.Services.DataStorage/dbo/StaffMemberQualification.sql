CREATE TABLE [dbo].[StaffMemberQualification]
(
	[StaffMemberId] INT NOT NULL , 
    [QualificationId] INT NOT NULL, 
    [ExpiryDate] DATETIME NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [LastUpdatedDate] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [LastUpdatedBy] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([StaffMemberId], [QualificationId])
)
