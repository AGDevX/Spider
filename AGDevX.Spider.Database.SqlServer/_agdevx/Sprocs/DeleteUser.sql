CREATE PROCEDURE [agdevx].DeleteUser
	@id UNIQUEIDENTIFIER = NULL,
	@email NVARCHAR(50) = NULL
AS


-- An Id wasn't provided and we cannot look it up
IF (@id is null and @email is null)
BEGIN
	RETURN
END


-- An Id wasn't provided but we can look it up
IF (@id is null and @email is not null)
BEGIN
	SET @id = (select Id from [agdevx].Users where Email = @email)
END


DELETE	u
FROM	[agdevx].Users u
WHERE	u.Id = @id