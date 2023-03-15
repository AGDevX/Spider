CREATE PROCEDURE [agdevx].GetUserInfo
	@userId UNIQUEIDENTIFIER = NULL,
	@externalUserId NVARCHAR(100) = NULL,
	@email NVARCHAR(50) = NULL
AS

-- No argument was provided. Do not allow the sproc to return all Users
IF (@userId  is null and @externalUserId is null and @email is null)
BEGIN
	RETURN
END


-- Retrieving by either externalUserId or email
IF (@userId is null)
BEGIN

	IF (@externalUserId is not null)
	BEGIN
		SET @userId = (select Id from [agdevx].ExternalUserIds where ExternalId = @externalUserId)
	END
	ELSE IF (@email is not null)
	BEGIN
		SET @userId = (select Id from [agdevx].Users where Email = @email)
	END

	IF (@userId is null)
	BEGIN
		RETURN
	END

END


-- User
SELECT	u.Id
			,u.IsActive
			,u.Email
			,u.FirstName
			,u.MiddleName
			,u.LastName
			,u.Suffix
FROM	[agdevx].Users u
WHERE	u.Id = @userId


-- External UserIds
SELECT	xui.Id
			,xui.IsActive
			,xui.UserId
			,xui.ExternalId
FROM	[agdevx].ExternalUserIds xui
WHERE	xui.UserId = @userId


-- User Roles
SELECT	ur.UserId
			,ur.RoleId
			,r.[Name] AS RoleName
			,r.Code AS RoleCode
			,r.[Description] AS RoleDescription
			,r.IsActive AS RoleIsActive
FROM	[agdevx].UserRoles ur
			JOIN [agdevx].Roles r ON r.Id = ur.RoleId
WHERE	ur.UserId = @userId