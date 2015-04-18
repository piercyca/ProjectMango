using System.IO;
using System.Reflection;

namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Elmah : DbMigration
    {
        public override void Up()
        {
            var sqlStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Mango.Core.Migrations.ELMAH-db-SQLServer.sql");
            using (var sqlStreamReader = new StreamReader(sqlStream))
            {
                string sqlScript = sqlStreamReader.ReadToEnd();
                ExecuteSqlScript(sqlScript);
            }
        }

        public override void Down()
        {
            DropTable("ELMAH_Error");
            Sql("DROP PROCEDURE ELMAH_GetErrorXml");
            Sql("DROP PROCEDURE ELMAH_GetErrorsXml");
            Sql("DROP PROCEDURE ELMAH_LogError");
        }

        void ExecuteSqlScript(string sqlScript)
        {
            string[] sql = sqlScript.Split(new[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sqlCommand in sql)
            {
                if (!string.IsNullOrWhiteSpace(sqlCommand))
                    Sql(sqlCommand);
            }
        }
    }
}
