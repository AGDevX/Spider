CREATE TABLE [agdevx].ExternalUserIds
(
	[Id]                  UNIQUEIDENTIFIER	NOT NULL CONSTRAINT PK_ExternalUserIds_Id PRIMARY KEY CLUSTERED DEFAULT NEWSEQUENTIALID(),
	[CreatedBy]			  UNIQUEIDENTIFIER	NOT NULL,
	[CreatedAt]			  DATETIME2(7)		NOT NULL CONSTRAINT DF_ExternalUserIds_CreatedAt DEFAULT GETUTCDATE(),
	[ModifiedBy]	      UNIQUEIDENTIFIER	NOT NULL,
	[ModifiedAt]		  DATETIME2(7)		NOT NULL CONSTRAINT DF_ExternalUserIds_ModifiedAt DEFAULT GETUTCDATE(),
	[IsActive]	          BIT				NOT NULL CONSTRAINT DF_ExternalUserIds_IsActive DEFAULT 1,
	[UserId]			  UNIQUEIDENTIFIER  NOT NULL,
	[ExternalId]		  NVARCHAR(100)		NOT NULL

	CONSTRAINT CHK_ExternalUserIds_Id CHECK (Id <> '00000000-0000-0000-0000-000000000000'),
	CONSTRAINT FK_ExternalUserIds_Users_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES [agdevx].Users(Id),
	CONSTRAINT FK_ExternalUserIds_Users_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES [agdevx].Users(Id),
	CONSTRAINT FK_ExternalUserIds_Users_UserId FOREIGN KEY (UserId) REFERENCES [agdevx].Users(Id),
	CONSTRAINT UC_ExternalUserIds_UserId_ExternalId UNIQUE (UserId, ExternalId)
)
GO

CREATE NONCLUSTERED INDEX IX_ExternalUserIds_UserId ON [agdevx].ExternalUserIds (UserId ASC)
GO
CREATE NONCLUSTERED INDEX IX_ExternalUserIds_ExternalId ON [agdevx].ExternalUserIds (ExternalId ASC)
GO