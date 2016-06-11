CREATE PROCEDURE [dbo].[CreateHome]
    @Name VARCHAR(255),
	@ExecutingUser NVARCHAR(50)
AS
	INSERT INTO Home (Name, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	VALUES (@Name, @ExecutingUser, GETDATE(), @ExecutingUser, GETDATE())

RETURN @@IDENTITY
