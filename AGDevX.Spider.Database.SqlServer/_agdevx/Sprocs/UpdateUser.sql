CREATE PROCEDURE [agdevx].UpdateUser
	@by UNIQUEIDENTIFIER,
	@id UNIQUEIDENTIFIER,
	@isActive BIT = NULL,
	@firstName NVARCHAR(25) = NULL,
	@lastName NVARCHAR(25) = NULL,
	@email NVARCHAR(50) = NULL
AS


UPDATE	u
SET		u.ModifiedBy = @by
			,u.ModifiedAt = GETUTCDATE()
			,u.IsActive = COALESCE(@isActive, u.IsActive)
			,u.FirstName = COALESCE(@firstName, u.FirstName)
			,u.LastName = COALESCE(@lastName, u.LastName)
			,u.Email = COALESCE(@email, u.Email)
FROM	[agdevx].Users u
WHERE	u.Id = @id