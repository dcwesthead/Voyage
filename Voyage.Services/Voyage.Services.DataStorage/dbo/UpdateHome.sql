CREATE PROCEDURE [dbo].[UpdateHome]
	@HomeId INT,
    @Name VARCHAR(255),
	@ExecutingUser NVARCHAR(50)
AS
	UPDATE Home 
	SET
		Name = @Name, 
		LastUpdatedBy = @ExecutingUser, 
		LastUpdatedDate = GETDATE()
	WHERE 
	Id = @HomeId

RETURN @HomeId