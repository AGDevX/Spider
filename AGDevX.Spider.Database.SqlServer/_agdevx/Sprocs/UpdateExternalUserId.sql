CREATE PROCEDURE [agdevx].UpdateExternalUserId
	@by UNIQUEIDENTIFIER,
	@id UNIQUEIDENTIFIER,
	@isActive BIT = NULL
AS


UPDATE	xui
SET		xui.ModifiedBy = @by
			,xui.ModifiedAt = GETUTCDATE()
			,xui.IsActive = COALESCE(@isActive, xui.IsActive)
FROM	[agdevx].ExternalUserIds xui
WHERE	xui.Id = @id