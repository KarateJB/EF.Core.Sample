using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFCore.Dal.Migrations
{
    public partial class CreateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(48)", nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<byte[]>(type: "bytea", nullable: true),
                    CardNo = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CardNo", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, new byte[] { 195, 13, 4, 7, 3, 2, 9, 21, 130, 214, 105, 231, 20, 121, 99, 210, 68, 1, 104, 53, 220, 71, 169, 38, 179, 192, 250, 144, 58, 162, 84, 177, 101, 214, 85, 218, 135, 82, 202, 136, 62, 194, 66, 115, 125, 66, 113, 247, 187, 10, 22, 41, 45, 129, 197, 17, 116, 102, 235, 56, 182, 12, 219, 167, 13, 243, 180, 73, 56, 161, 157, 152, 212, 57, 188, 99, 136, 94, 89, 161, 174, 73, 112, 174, 40 }, "JB", "$1$h.1aa63v$V1eKBFkVOLQ2oc3lmTeFD/", new byte[] { 195, 13, 4, 7, 3, 2, 154, 39, 85, 151, 179, 241, 64, 10, 127, 210, 59, 1, 215, 73, 253, 75, 109, 215, 3, 147, 228, 229, 17, 135, 219, 16, 89, 215, 41, 3, 90, 169, 194, 234, 56, 65, 214, 32, 19, 157, 232, 29, 26, 30, 79, 49, 180, 253, 55, 150, 178, 131, 129, 150, 234, 31, 26, 133, 28, 34, 198, 134, 67, 201, 164, 11, 48, 109, 38, 13 } },
                    { 2, new byte[] { 195, 13, 4, 7, 3, 2, 161, 86, 249, 87, 29, 142, 108, 79, 100, 210, 68, 1, 19, 188, 233, 242, 130, 178, 19, 248, 77, 164, 35, 176, 221, 78, 10, 232, 39, 3, 6, 97, 158, 222, 228, 15, 56, 165, 51, 234, 204, 3, 212, 114, 9, 19, 33, 16, 27, 83, 205, 5, 173, 77, 204, 206, 143, 91, 134, 167, 92, 4, 212, 53, 29, 16, 76, 14, 214, 166, 25, 142, 131, 220, 8, 147, 149, 215, 110 }, "Amy", "$1$eopByFK0$19oZ4VsMk3fmc9luqwzOi.", new byte[] { 195, 13, 4, 7, 3, 2, 61, 83, 8, 176, 245, 7, 222, 171, 123, 210, 59, 1, 179, 113, 22, 36, 194, 7, 67, 64, 168, 92, 102, 27, 113, 228, 199, 169, 173, 8, 254, 219, 148, 18, 161, 19, 87, 231, 254, 239, 239, 40, 38, 31, 27, 214, 238, 252, 208, 146, 234, 213, 7, 209, 177, 58, 117, 4, 80, 151, 225, 242, 18, 170, 74, 57, 71, 201, 60, 238 } }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
