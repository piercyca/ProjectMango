SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

  CREATE VIEW [dbo].[vw_aspnet_Profiles]
  AS SELECT [UserId], [LastUpdatedDate],
      [DataSize]=  DATALENGTH([PropertyNames])
                 + DATALENGTH([PropertyValuesString])
                 + DATALENGTH([PropertyValuesBinary])
  FROM [dbo].[aspnet_Profile]
  
GO
GRANT SELECT ON  [dbo].[vw_aspnet_Profiles] TO [aspnet_Profile_ReportingAccess]
GO
