CREATE PROCEDURE [dbo].[CreateStaffMemberQualification]
    @StaffMemberId INT, 
    @QualificationId INT, 
	@ExpiryDate DATETIME,
	@ExecutingUser NVARCHAR(50)
AS
	INSERT INTO StaffMemberQualification(StaffMemberId, QualificationId, ExpiryDate, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	VALUES (@Name, @Description, @ExecutingUser, GETDATE(), @ExecutingUser, GETDATE())

RETURN @@IDENTITY
