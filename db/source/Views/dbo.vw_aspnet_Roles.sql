SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

  CREATE VIEW [dbo].[vw_aspnet_Roles]
  AS SELECT [ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]
  FROM [dbo].[aspnet_Roles]
  
GO
GRANT SELECT ON  [dbo].[vw_aspnet_Roles] TO [aspnet_Roles_ReportingAccess]
GO
