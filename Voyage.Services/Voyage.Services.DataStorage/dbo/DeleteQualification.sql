CREATE PROCEDURE [dbo].[DeleteQualification]
	@QualificationId INT,
	@ExecutingUser NVARCHAR(50)
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE QualificationId = @QualificationId ))
BEGIN
	RETURN -1
END ELSE BEGIN
	UPDATE Qualification 
	SET
		Deleted = 1,
		LastUpdatedBy = @ExecutingUser,
		LastUpdatedDate = GETDATE()
	WHERE Id = @QualificationId
	RETURN @@ROWCOUNT
END

RETURN 0