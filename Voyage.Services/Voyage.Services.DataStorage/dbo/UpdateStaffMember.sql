CREATE PROCEDURE [dbo].[UpdateStaffMember]
	@StaffMemberId INT,
    @Forename VARCHAR(50), 
    @Surname VARCHAR(50), 
    @DateOfBirth DATETIME,
	@ExecutingUser NVARCHAR(50)
AS
	UPDATE StaffMember 
	SET
		Forename = @Forename, 
		Surname = @Surname, 
		DateOfBirth = @DateOfBirth, 
		LastUpdatedBy = @ExecutingUser, 
		LastUpdatedDate = GETDATE()
	WHERE 
	Id = @StaffMemberId

RETURN @StaffMemberId