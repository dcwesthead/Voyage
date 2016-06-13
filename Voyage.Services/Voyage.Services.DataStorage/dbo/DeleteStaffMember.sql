CREATE PROCEDURE [dbo].[DeleteStaffMember]
	@StaffMemberId INT,
	@ExecutingUser NVARCHAR(50)
AS
IF(EXISTS(SELECT COUNT(1) FROM StaffMemberQualification WHERE StaffMemberId = @StaffMemberId ))
BEGIN
	RETURN -1
END ELSE BEGIN
	UPDATE Qualification 
	SET
		Deleted = 1,
		LastUpdatedBy = @ExecutingUser,
		LastUpdatedDate = GETDATE()
	WHERE Id = @StaffMemberId
	RETURN @@ROWCOUNT
END

RETURN 0