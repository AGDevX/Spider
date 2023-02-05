CREATE PROCEDURE [agdevx].AddUser
	@by UNIQUEIDENTIFIER,
	@isActive BIT = 1,
	@firstName NVARCHAR(25),
	@lastName NVARCHAR(25),
	@email NVARCHAR(50)
AS


-- Insert the new User
INSERT INTO [agdevx].Users
	(CreatedBy, ModifiedBy, IsActive, FirstName, LastName, Email)
VALUES
	(@by, @by, @isActive, @firstName, @lastName, @email)


-- Select the new Id
SELECT	u.Id
FROM	[agdevx].Users u
WHERE	u.Email = @email