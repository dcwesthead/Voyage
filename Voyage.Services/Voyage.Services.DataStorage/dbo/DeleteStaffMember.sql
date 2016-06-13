CREATE PROCEDURE [dbo].[DeleteStaffMember]
	@StaffMemberId INT
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE StaffMemberId = @StaffMemberId ))
BEGIN
	RETURN -1
END ELSE BEGIN
	DELETE FROM StaffMember WHERE Id = @StaffMemberId
	RETURN @@ROWCOUNT
END

RETURN 0