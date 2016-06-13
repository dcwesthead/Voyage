CREATE PROCEDURE [dbo].[UpdateStaffMemberQualification]
	@StaffMemberId INT,
	@QualificationId INT,
	@ExpiryDate DATETIME,
	@ExecutingUser VARCHAR(50)
AS
	UPDATE StaffMemberQualification
	SET
		ExpiryDate = @ExpiryDate,
		LastUpdatedBy = @ExecutingUser,
		LastUpdatedDate = GETDATE()
	WHERE
		StaffMemberId = @StaffMemberId AND QualificationId = @QualificationId
RETURN @@ROWCOUNT
