using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFCore.Dal.Migrations
{
    public partial class InitCreate : Migration
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
                    { 1, new byte[] { 195, 13, 4, 7, 3, 2, 185, 29, 246, 12, 188, 187, 199, 187, 102, 210, 68, 1, 146, 174, 186, 238, 149, 205, 211, 216, 247, 43, 195, 208, 147, 16, 12, 74, 88, 168, 74, 237, 200, 216, 72, 203, 234, 194, 174, 233, 201, 178, 234, 129, 160, 231, 183, 82, 16, 204, 236, 242, 198, 88, 255, 90, 127, 21, 177, 75, 151, 250, 82, 53, 249, 90, 47, 23, 210, 168, 240, 244, 38, 135, 128, 68, 14, 130, 154 }, "JB", null, new byte[] { 195, 13, 4, 7, 3, 2, 118, 181, 26, 17, 101, 54, 49, 122, 109, 210, 59, 1, 34, 148, 185, 58, 30, 211, 112, 43, 144, 240, 74, 38, 190, 251, 144, 244, 71, 34, 217, 213, 179, 72, 40, 70, 62, 163, 2, 107, 173, 175, 74, 255, 59, 150, 129, 60, 124, 85, 92, 222, 237, 255, 84, 135, 211, 204, 193, 253, 186, 66, 15, 85, 120, 31, 6, 72, 130, 176 } },
                    { 2, new byte[] { 195, 13, 4, 7, 3, 2, 212, 70, 145, 29, 142, 129, 56, 42, 121, 210, 68, 1, 254, 21, 188, 118, 221, 179, 75, 86, 150, 244, 77, 199, 65, 228, 98, 130, 179, 57, 181, 197, 150, 159, 93, 111, 214, 217, 253, 116, 93, 248, 124, 129, 141, 231, 251, 21, 203, 82, 249, 138, 204, 137, 132, 133, 0, 36, 0, 152, 83, 219, 92, 36, 5, 3, 149, 48, 230, 104, 212, 175, 157, 23, 45, 15, 126, 66, 201 }, "Amy", null, new byte[] { 195, 13, 4, 7, 3, 2, 56, 107, 98, 93, 116, 148, 205, 62, 113, 210, 59, 1, 86, 15, 177, 97, 173, 23, 165, 160, 97, 55, 96, 214, 42, 68, 157, 128, 84, 227, 46, 211, 220, 227, 227, 163, 75, 191, 13, 12, 198, 129, 213, 100, 53, 47, 154, 191, 179, 230, 103, 24, 101, 222, 124, 109, 219, 27, 42, 202, 203, 133, 11, 244, 76, 20, 63, 247, 215, 19 } }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
