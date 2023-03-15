CREATE PROCEDURE [agdevx].AddUser
	@createdBy UNIQUEIDENTIFIER,
	@isActive BIT = 1,
	@firstName NVARCHAR(25),
	@middleName NVARCHAR(25) = NULL,
	@lastName NVARCHAR(25),
	@suffix NVARCHAR(5) = NULL,
	@email NVARCHAR(50),
	@externalId NVARCHAR(100) = NULL,
	@roleIds GuidList READONLY
AS


-- Insert the new User
INSERT INTO [agdevx].Users
	(CreatedBy, ModifiedBy, IsActive, FirstName, MiddleName, LastName, Suffix, Email)
VALUES
	(@createdBy, @createdBy, @isActive, @firstName, @middleName, @lastName, @suffix, @email)


DECLARE @userId UNIQUEIDENTIFIER = (select u.Id from [agdevx].Users u where  u.Email = @email)


-- Insert the new External Id
IF (@externalId is not null)
BEGIN

	INSERT INTO [agdevx].ExternalUserIds
		(CreatedBy, ModifiedBy, IsActive, UserId, ExternalId)
	VALUES
		(@createdBy, @createdBy, @isActive, @userId, @externalId)

END

-- Insert the Roles
IF (not exists (select 1 from @roleIds))
BEGIN

	INSERT INTO [agdevx].UserRoles (CreatedBy, UserId, RoleId)
	SELECT		@createdBy
					,@userId
					,[RoleIds].Id
	FROM		(select Id from [agdevx].Roles where IsDefault = 1) AS [RoleIds]

END
ELSE
BEGIN

	INSERT INTO [agdevx].UserRoles (CreatedBy, UserId, RoleId)
	SELECT		@createdBy
					,@userId
					,r.Id
	FROM		@roleIds r

END


-- Return the new UserId
SELECT @userId AS UserId