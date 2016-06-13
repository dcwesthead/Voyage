CREATE PROCEDURE [dbo].[UpdateQualification]
	@QualificationId INT,
    @Name VARCHAR(100), 
    @Description VARCHAR(MAX), 
	@ExecutingUser NVARCHAR(50)
AS
	UPDATE Qualification 
	SET
		Name = @Name,
		Description = @Description,
		LastUpdatedBy = @ExecutingUser, 
		LastUpdatedDate = GETDATE()
	WHERE 
	Id = @QualificationId

RETURN @QualificationId