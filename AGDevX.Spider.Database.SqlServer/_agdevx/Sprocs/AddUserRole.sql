CREATE PROCEDURE [agdevx].AddUserRole
	@by UNIQUEIDENTIFIER,
	@userId UNIQUEIDENTIFIER,
	@roleId UNIQUEIDENTIFIER
AS


-- Insert the new User Role
INSERT INTO [agdevx].UserRoles
	(CreatedBy, UserId, RoleId)
VALUES
	(@by, @userId, @roleId)