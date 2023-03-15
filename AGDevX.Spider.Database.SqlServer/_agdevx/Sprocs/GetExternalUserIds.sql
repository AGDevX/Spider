CREATE PROCEDURE [agdevx].GetExternalUserIds
	@userId UNIQUEIDENTIFIER = NULL,
	@email NVARCHAR(50) = NULL
AS


-- Neither argument was provided. Do not allow the sproc to return all External User Ids
IF (@userId is null and @email is null)
BEGIN
	RETURN
END


-- Retrieving by email
IF (@userId is null and @email is not null)
BEGIN
	SET @userId = (select Id from [agdevx].Users where Email = @email)
END


SELECT	xui.*
FROM	[agdevx].ExternalUserIds xui
WHERE	xui.UserId = @userId