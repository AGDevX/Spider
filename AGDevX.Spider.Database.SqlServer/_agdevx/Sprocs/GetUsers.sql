CREATE PROCEDURE [agdevx].GetUsers
	@userId UNIQUEIDENTIFIER = NULL,
	@email NVARCHAR(50) = NULL
AS


SELECT	u.*
FROM	[agdevx].Users u
WHERE	(@userId is null or u.Id = @userId)
			AND (@email is null or u.Email = @email)