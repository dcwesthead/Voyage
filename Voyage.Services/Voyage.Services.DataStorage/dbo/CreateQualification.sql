CREATE PROCEDURE [dbo].[CreateQualification]
    @Name NVARCHAR(100), 
    @Description NVARCHAR(MAX), 
	@ExecutingUser NVARCHAR(50)
AS
	INSERT INTO Qualification(Name, [Description], CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	VALUES (@Name, @Description, @ExecutingUser, GETDATE(), @ExecutingUser, GETDATE())

RETURN @@IDENTITY
