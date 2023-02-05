CREATE PROCEDURE [agdevx].AddExternalUserId
	@by UNIQUEIDENTIFIER,
	@isActive BIT = 1,
	@userId UNIQUEIDENTIFIER,
	@externalId NVARCHAR(100)
AS


-- Insert the new External User Id
INSERT INTO [agdevx].ExternalUserIds
	(CreatedBy, ModifiedBy, IsActive, UserId, ExternalId)
VALUES
	(@by, @by, @isActive, @userId, @externalId)


-- Select the new Id
SELECT	xui.Id
FROM	[agdevx].ExternalUserIds xui
WHERE	xui.UserId = @userId
			AND xui.ExternalId = @externalId