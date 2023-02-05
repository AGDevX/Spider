CREATE PROCEDURE [agdevx].DeleteExternalUserId
	@id UNIQUEIDENTIFIER = NULL,
	@userId UNIQUEIDENTIFIER = NULL,
	@externalId NVARCHAR(100) = NULL
AS


-- An Id wasn't provided and we cannot look it up
IF (@id is null and (@userId is null or @externalId is null))
BEGIN
	RETURN
END


-- An Id wasn't provided but we can look it up
IF (@id is null and @userId is not null and @externalId is not null)
BEGIN
	SET @id = (select Id from [agdevx].ExternalUserIds where UserId = @userId and ExternalId = @externalId)
END


DELETE	xui
FROM	[agdevx].ExternalUserIds xui
WHERE	xui.Id = @id