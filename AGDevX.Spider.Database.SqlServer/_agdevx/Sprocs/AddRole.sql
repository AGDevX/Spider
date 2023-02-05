CREATE PROCEDURE [agdevx].AddRole
	@by UNIQUEIDENTIFIER,
	@isActive BIT = 1,
	@name NVARCHAR(25),
	@code NVARCHAR(10),
	@description NVARCHAR(200)
AS


-- Insert the new Role
INSERT INTO [agdevx].Roles
	(CreatedBy, ModifiedBy, IsActive, [Name], Code, [Description])
VALUES
	(@by, @by, @isActive, @name, @code, @description)


-- Select the new Id
SELECT	r.Id
FROM	[agdevx].Roles r
WHERE	r.Code = @code