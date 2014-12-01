SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

  CREATE VIEW [dbo].[vw_aspnet_Users]
  AS SELECT [ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]
  FROM [dbo].[aspnet_Users]
  
GO
GRANT SELECT ON  [dbo].[vw_aspnet_Users] TO [aspnet_Membership_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Users] TO [aspnet_Personalization_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Users] TO [aspnet_Profile_ReportingAccess]
GRANT SELECT ON  [dbo].[vw_aspnet_Users] TO [aspnet_Roles_ReportingAccess]
GO
