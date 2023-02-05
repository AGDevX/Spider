CREATE PROCEDURE [agdevx].GetUserRoles
	@userId UNIQUEIDENTIFIER
AS


SELECT	ur.*
FROM	[agdevx].UserRoles ur
WHERE	ur.UserId = @userId