using System.IO;

namespace EFCore.Dal.Utils.MigrationBuilders
{
    /// <summary>
    /// MigrationBuilder extensions
    /// </summary>
    public static partial class MigrationBuilderExtensions
    {
        private const string RootDirName = "Sqls";
        private static string datetimeDirName = string.Empty;

        /// <summary>
        /// Read SQL from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>SQL</returns>
        private static string ReadMigrationSql(string path)
        {
            FileInfo file = new FileInfo(path);
            string script = file.OpenText().ReadToEnd();
            return script;
        }
    }
}
