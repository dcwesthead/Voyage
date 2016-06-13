CREATE PROCEDURE [dbo].[DeleteStaffMemberQualification]
	@StaffMemberId INT,
	@QualificationId INT
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE StaffMemberId = @StaffMemberId AND QualificationId = @QualificationId ))
BEGIN
	DELETE FROM StaffMemberQualification WHERE StaffMemberId = @StaffMemberId AND QualificationId = @QualificationId
	RETURN @@ROWCOUNT
END

RETURN 0