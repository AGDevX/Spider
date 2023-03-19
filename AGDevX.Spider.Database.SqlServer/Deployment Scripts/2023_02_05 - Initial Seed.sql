DECLARE @now DATETIME2(7) = GETUTCDATE()


/* ---------- Users ---------- */
BEGIN

	DECLARE @userSysId UNIQUEIDENTIFIER = 'f08f4be5-35a3-4864-9b24-e7ec5b441c3f'

	INSERT INTO [agdevx].Users (Id, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, FirstName, LastName, Email)
	SELECT @userSysId, @userSysId, @now, @userSysId, @now, 1, 'AGDevX', 'System', 'agdevxsystem@reddwarfjmcagdx.com'
	WHERE NOT EXISTS (select 1 from [agdevx].Users u where u.Id = @userSysId)

	DECLARE @emailAg NVARCHAR(50) = 'august.geier@reddwarfjmcagdx.com'
	INSERT INTO [agdevx].Users (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, FirstName, LastName, Email)
	SELECT @userSysId, @now, @userSysId, @now, 1, 'August', 'Geier', @emailAg
	WHERE NOT EXISTS (select 1 from [agdevx].Users u where u.Email = @emailAg)

	DECLARE @emailDl NVARCHAR(50) = 'dave.lister@reddwarfjmcagdx.com'
	INSERT INTO [agdevx].Users (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, FirstName, LastName, Suffix, Email)
	SELECT @userSysId, @now, @userSysId, @now, 1, 'Dave', 'Lister', 'Sir', @emailDl
	WHERE NOT EXISTS (select 1 from [agdevx].Users u where u.Email = @emailDl)

	DECLARE @emailAr NVARCHAR(50) = 'arnold.rimmer@reddwarfjmcagdx.com'
	INSERT INTO [agdevx].Users (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, FirstName, MiddleName, LastName, Email)
	SELECT @userSysId, @now, @userSysId, @now, 1, 'Arnold', 'Judas', 'Rimmer', @emailAr
	WHERE NOT EXISTS (select 1 from [agdevx].Users u where u.Email = @emailAr)

	DECLARE @userAgId UNIQUEIDENTIFIER = (select Id from [agdevx].Users where Email = @emailAg)
	DECLARE @userDlId UNIQUEIDENTIFIER = (select Id from [agdevx].Users where Email = @emailDl)
	DECLARE @userArId UNIQUEIDENTIFIER = (select Id from [agdevx].Users where Email = @emailAr)

END


/* ---------- External User Ids ---------- */
BEGIN

	DECLARE @xuiAg1 NVARCHAR(100) = 'EX_ID_AG_1'
	INSERT INTO [agdevx].ExternalUserIds (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, UserId, ExternalId)
	SELECT @userAgId, @now, @userAgId, @now, 1, @userAgId, @xuiAg1
	WHERE NOT EXISTS (select 1 from [agdevx].ExternalUserIds xui where xui.UserId = @userAgId and xui.ExternalId = @xuiAg1)

	DECLARE @xuiAg2 NVARCHAR(100) = 'EX_ID_AG_2'
	INSERT INTO [agdevx].ExternalUserIds (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, UserId, ExternalId)
	SELECT @userAgId, @now, @userAgId, @now, 1, @userAgId, @xuiAg2
	WHERE NOT EXISTS (select 1 from [agdevx].ExternalUserIds xui where xui.UserId = @userAgId and xui.ExternalId = @xuiAg2)

	DECLARE @xuiDl1 NVARCHAR(100) = 'EX_ID_DL_1'
	INSERT INTO [agdevx].ExternalUserIds (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, UserId, ExternalId)
	SELECT @userAgId, @now, @userAgId, @now, 1, @userDlId, @xuiDl1
	WHERE NOT EXISTS (select 1 from [agdevx].ExternalUserIds xui where xui.UserId = @userDlId and xui.ExternalId = @xuiDl1)

	DECLARE @xuiAr1 NVARCHAR(100) = 'EX_ID_AR_1'
	INSERT INTO [agdevx].ExternalUserIds (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, UserId, ExternalId)
	SELECT @userAgId, @now, @userAgId, @now, 1, @userArId, @xuiAr1
	WHERE NOT EXISTS (select 1 from [agdevx].ExternalUserIds xui where xui.UserId = @userArId and xui.ExternalId = @xuiAr1)

END



/* ---------- Roles ---------- */
BEGIN

	-- Service
	DECLARE @roleServiceCode NVARCHAR(10) = 'SERVICE'
	INSERT INTO [agdevx].Roles (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, IsDefault, [Name], Code, [Description])
	SELECT @userAgId, @now, @userAgId, @now, 1, 0, 'Service', @roleServiceCode, 'Service account access level'
	WHERE NOT EXISTS (select 1 from [agdevx].Roles r where r.Code = @roleServiceCode)

	-- AGDevX Admin
	DECLARE @roleAGDevXAdminCode NVARCHAR(10) = 'AGDXADMIN'
	INSERT INTO [agdevx].Roles (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, IsDefault, [Name], Code, [Description])
	SELECT @userAgId, @now, @userAgId, @now, 1, 0, 'AGDevX Admin', @roleAGDevXAdminCode, 'A member of the AGDevX team'
	WHERE NOT EXISTS (select 1 from [agdevx].Roles r where r.Code = @roleAGDevXAdminCode)

	-- Admin
	DECLARE @roleAdminCode NVARCHAR(10) = 'ADMIN'
	INSERT INTO [agdevx].Roles (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, IsDefault, [Name], Code, [Description])
	SELECT @userAgId, @now, @userAgId, @now, 1, 0, 'Admin', @roleAdminCode, 'Administrator'
	WHERE NOT EXISTS (select 1 from [agdevx].Roles r where r.Code = @roleAdminCode)

	-- Normal
	DECLARE @roleNormalCode NVARCHAR(10) = 'NORMAL'
	INSERT INTO [agdevx].Roles (CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, IsDefault, [Name], Code, [Description])
	SELECT @userAgId, @now, @userAgId, @now, 1, 1, 'Normal', @roleNormalCode, 'Typical user access level'
	WHERE NOT EXISTS (select 1 from [agdevx].Roles r where r.Code = @roleNormalCode)

	DECLARE @roleServiceId UNIQUEIDENTIFIER = (select Id from [agdevx].Roles r where r.Code = @roleServiceCode)
	DECLARE @roleAGDevXAdminId UNIQUEIDENTIFIER = (select Id from [agdevx].Roles r where r.Code = @roleAGDevXAdminCode)
	DECLARE @roleAdminId UNIQUEIDENTIFIER = (select Id from [agdevx].Roles r where r.Code = @roleAdminCode)
	DECLARE @roleNormalId UNIQUEIDENTIFIER = (select Id from [agdevx].Roles r where r.Code = @roleNormalCode)

END


/* ---------- UserRoles ---------- */
BEGIN

	-- System
	INSERT INTO [agdevx].UserRoles (CreatedBy, CreatedAt, UserId, RoleId)
	SELECT @userAgId, @now, @userSysId, @roleServiceId
	WHERE NOT EXISTS (select 1 from [agdevx].UserRoles ur where ur.UserId = @userSysId and ur.RoleId = @roleServiceId)

	-- August
	INSERT INTO [agdevx].UserRoles (CreatedBy, CreatedAt, UserId, RoleId)
	SELECT @userAgId, @now, @userAgId, @roleAGDevXAdminId
	WHERE NOT EXISTS (select 1 from [agdevx].UserRoles ur where ur.UserId = @userAgId and ur.RoleId = @roleAGDevXAdminId)

	INSERT INTO [agdevx].UserRoles (CreatedBy, CreatedAt, UserId, RoleId)
	SELECT @userAgId, @now, @userAgId, @roleAdminId
	WHERE NOT EXISTS (select 1 from [agdevx].UserRoles ur where ur.UserId = @userAgId and ur.RoleId = @roleAdminId)

	-- Lister
	INSERT INTO [agdevx].UserRoles (CreatedBy, CreatedAt, UserId, RoleId)
	SELECT @userAgId, @now, @userDlId, @roleAdminId
	WHERE NOT EXISTS (select 1 from [agdevx].UserRoles ur where ur.UserId = @userDlId and ur.RoleId = @roleAdminId)

	-- Rimmer
	INSERT INTO [agdevx].UserRoles (CreatedBy, CreatedAt, UserId, RoleId)
	SELECT @userAgId, @now, @userArId, @roleNormalId
	WHERE NOT EXISTS (select 1 from [agdevx].UserRoles ur where ur.UserId = @userArId and ur.RoleId = @roleNormalId)

END