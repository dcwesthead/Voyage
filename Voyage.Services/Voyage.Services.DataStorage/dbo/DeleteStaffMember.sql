CREATE PROCEDURE [dbo].[DeleteStaffMember]
	@StaffMemberId INT
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMember WHERE Id = @StaffMemberId))
BEGIN
	DELETE FROM StaffMember WHERE Id = @StaffMemberId
	RETURN @@ROWCOUNT
END

RETURN 0