SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

  CREATE VIEW [dbo].[vw_aspnet_Applications]
  AS SELECT [ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]
  FROM [dbo].[aspnet_Applications]
  
GO
GRANT SELECT ON  [dbo].[vw_aspnet_Applications] TO [aspnet_Membership_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Applications] TO [aspnet_Personalization_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Applications] TO [aspnet_Profile_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Applications] TO [aspnet_Roles_ReportingAccess]
GO
