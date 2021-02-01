using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Dal.Utils.MigrationBuilders
{
    /// <summary>
    /// MigrationBuilder extensions
    /// </summary>
    public static partial class PgMigrationBuilderExtensions
    {
        /// <summary>
        /// Create DB functions
        /// </summary>
        /// <param name="migrationBuilder">MigrationBuilder</param>
        public static void CreatePgCryptoFunctions_20200108053432(this MigrationBuilder migrationBuilder)
        {
            datetimeDirName = "20200108053432";

            var path = string.Empty;
            var script = string.Empty;

            // Create Extension
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "01.create_extension.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create Schema and store secret
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "02.store_secret.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create functions
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "03.create_functions.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);
        }
    }
}
