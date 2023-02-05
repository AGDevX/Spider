CREATE PROCEDURE [agdevx].UpdateRole
	@by UNIQUEIDENTIFIER,
	@id UNIQUEIDENTIFIER,
	@isActive BIT = NULL,
	@name NVARCHAR(25) = NULL,
	@code NVARCHAR(10) = NULL,
	@description NVARCHAR(200) = NULL
AS


UPDATE	r
SET		r.ModifiedBy = @by
			,r.ModifiedAt = GETUTCDATE()
			,r.IsActive = COALESCE(@isActive, r.IsActive)
			,r.[Name] = COALESCE(@name, r.[Name])
			,r.Code = COALESCE(@code, r.Code)
			,r.[Description] = COALESCE(@description, r.[Description])
FROM	[agdevx].Roles r
WHERE	r.Id = @id