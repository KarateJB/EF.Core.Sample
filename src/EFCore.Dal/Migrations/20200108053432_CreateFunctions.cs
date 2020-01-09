using EFCore.Dal.Utils.MigrationBuilders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Dal.Migrations
{
    public partial class CreateFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Custom migrate sqls
            migrationBuilder.CreatePgCryptoFunctions_20200108053432();
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
