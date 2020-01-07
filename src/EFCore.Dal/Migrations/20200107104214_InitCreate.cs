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
                    { 1, new byte[] { 195, 13, 4, 7, 3, 2, 83, 51, 8, 135, 229, 36, 30, 30, 97, 210, 68, 1, 194, 48, 43, 208, 113, 251, 132, 76, 33, 111, 72, 24, 220, 182, 25, 231, 5, 216, 116, 138, 72, 176, 184, 226, 152, 96, 204, 96, 37, 97, 173, 50, 105, 112, 233, 169, 190, 20, 221, 148, 37, 122, 228, 51, 36, 105, 145, 235, 230, 52, 87, 56, 126, 40, 227, 76, 7, 79, 232, 209, 157, 53, 36, 138, 188, 2, 233 }, "JB", "$1$dyLnVA55$84xep.0bexrGoTrJ3f/Ea/", new byte[] { 195, 13, 4, 7, 3, 2, 61, 245, 193, 171, 184, 46, 127, 26, 110, 210, 59, 1, 15, 113, 246, 29, 209, 130, 254, 146, 252, 131, 81, 90, 36, 219, 30, 147, 228, 152, 213, 120, 53, 175, 212, 208, 202, 195, 90, 42, 192, 74, 210, 249, 251, 54, 179, 216, 67, 48, 173, 41, 224, 142, 26, 179, 248, 117, 207, 86, 250, 30, 60, 243, 101, 77, 50, 132, 150, 159 } },
                    { 2, new byte[] { 195, 13, 4, 7, 3, 2, 235, 219, 226, 39, 59, 171, 232, 40, 120, 210, 68, 1, 155, 81, 31, 96, 138, 184, 228, 253, 122, 34, 200, 73, 8, 7, 138, 228, 110, 229, 171, 10, 187, 56, 47, 249, 147, 198, 106, 14, 243, 60, 151, 163, 94, 253, 171, 133, 65, 67, 50, 30, 12, 155, 76, 108, 88, 163, 6, 3, 233, 233, 187, 168, 57, 32, 171, 145, 207, 35, 219, 12, 82, 24, 169, 219, 122, 108, 45 }, "Amy", "$1$0lEbQESc$L4Y4pJ8vpFQj5JWYncdBA1", new byte[] { 195, 13, 4, 7, 3, 2, 9, 61, 90, 99, 219, 181, 71, 28, 108, 210, 59, 1, 179, 207, 74, 227, 172, 7, 225, 0, 152, 106, 126, 56, 15, 71, 24, 107, 27, 186, 99, 126, 25, 54, 241, 44, 206, 227, 103, 42, 142, 139, 7, 133, 104, 135, 159, 13, 65, 15, 56, 2, 152, 155, 200, 217, 123, 209, 48, 181, 144, 44, 55, 135, 160, 142, 74, 209, 141, 221 } }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
