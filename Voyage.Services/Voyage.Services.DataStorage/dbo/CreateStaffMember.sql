CREATE PROCEDURE [dbo].[CreateStaffMember]
    @Forename VARCHAR(50), 
    @Surname VARCHAR(50), 
    @DateOfBirth DATETIME,
	@ExecutingUser NVARCHAR(50)
AS
	INSERT INTO StaffMember (Forename, Surname, DateOfBirth, HomeId, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	VALUES (@Forename, @Surname, @DateOfBirth, null, @ExecutingUser, GETDATE(), @ExecutingUser, GETDATE())

RETURN @@IDENTITY
