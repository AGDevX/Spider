CREATE PROCEDURE [agdevx].DeleteRole
	@id UNIQUEIDENTIFIER = NULL,
	@code NVARCHAR(55) = NULL
AS


-- An Id wasn't provided and we cannot look it up
IF (@id is null and @code is null)
BEGIN
	RETURN
END


-- An Id wasn't provided but we can look it up
IF (@id is null and @code is not null)
BEGIN
	SET @id = (select Id from [agdevx].Roles where Code = @code)
END


DELETE	r
FROM	[agdevx].Roles r
WHERE	r.Id = @id