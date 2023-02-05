CREATE PROCEDURE [agdevx].DeleteUserRole
	@userId UNIQUEIDENTIFIER,
	@roleId UNIQUEIDENTIFIER
AS


DELETE	ur
FROM	[agdevx].UserRoles ur
WHERE	ur.UserId = @userId
			AND ur.RoleId = @roleId