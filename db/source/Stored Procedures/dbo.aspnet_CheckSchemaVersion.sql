SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    IF (EXISTS( SELECT  *
                FROM    dbo.aspnet_SchemaVersions
                WHERE   Feature = LOWER( @Feature ) AND
                        CompatibleSchemaVersion = @CompatibleSchemaVersion ))
        RETURN 0

    RETURN 1
END
GO
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Membership_BasicAccess]
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Membership_ReportingAccess]
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Profile_BasicAccess]
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Profile_ReportingAccess]
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Roles_BasicAccess]
GRANT EXECUTE ON  [dbo].[aspnet_CheckSchemaVersion] TO [aspnet_Roles_ReportingAccess]
GO
