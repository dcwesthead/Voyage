CREATE PROCEDURE [dbo].[DeleteHome]
	@HomeId INT,
	@ExecutingUser NVARCHAR(50)
AS
IF(EXISTS(SELECT COUNT(1) FROM Home WHERE Id = @HomeId))
BEGIN
	UPDATE Home 
	SET 
		Deleted = 1,
		LastUpdatedBy = @ExecutingUser,
		LastUpdatedDate = GETDATE()
	WHERE Id = @HomeId
	RETURN @@ROWCOUNT
END

RETURN 0