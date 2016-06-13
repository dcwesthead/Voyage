CREATE PROCEDURE [dbo].[DeleteQualification]
	@QualificationId INT
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE QualificationId = @QualificationId ))
BEGIN
	RETURN -1
END ELSE BEGIN
	DELETE FROM Qualification WHERE Id = @QualificationId
	RETURN @@ROWCOUNT
END

RETURN 0