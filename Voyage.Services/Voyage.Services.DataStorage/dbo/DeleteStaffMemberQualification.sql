CREATE PROCEDURE [dbo].[DeleteStaffMemberQualification]
	@StaffMemberId INT,
	@QualificationId INT,
	@ExecutingUser NVARCHAR(50)
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE StaffMemberId = @StaffMemberId AND QualificationId = @QualificationId ))
BEGIN
	UPDATE StaffMemberQualification 
	SET
		Deleted = 1,
		LastUpdatedBy = @ExecutingUser,
		LastUpdatedDate = GETDATE()
	WHERE StaffMemberId = @StaffMemberId AND QualificationId = @QualificationId
	RETURN @@ROWCOUNT
END

RETURN 0