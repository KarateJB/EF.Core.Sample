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
        /// Create DB functions (Up)
        /// </summary>
        /// <param name="migrationBuilder">MigrationBuilder</param>
        public static void CreatePgCryptoFunctions_20200108053432_Up(this MigrationBuilder migrationBuilder)
        {
            datetimeDirName = "20200108053432";

            var path = string.Empty;
            var script = string.Empty;

            // Create Extension
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "01.create_extension_up.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create Schema and store secret
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "02.store_secret_up.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create functions
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "03.create_functions_up.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);
        }

        /// <summary>
        /// Create DB functions (Up)
        /// </summary>
        /// <param name="migrationBuilder">MigrationBuilder</param>
        public static void CreatePgCryptoFunctions_20200108053432_Down(this MigrationBuilder migrationBuilder)
        {
            datetimeDirName = "20200108053432";

            var path = string.Empty;
            var script = string.Empty;

            // Create Extension
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "01.create_extension_down.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create Schema and store secret
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "02.store_secret_down.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);

            // Create functions
            path = Path.Combine(AppContext.BaseDirectory, RootDirName, SubDirName, datetimeDirName, "03.create_functions_down.sql");
            script = ReadMigrationSql(path);
            migrationBuilder.Sql(script);
        }
    }
}
