using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(48)", nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<byte[]>(type: "bytea", nullable: true),
                    CardNo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Secret = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CardNo", "Name", "Password", "Phone", "Secret" },
                values: new object[,]
                {
                    { new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86306"), new byte[] { 195, 13, 4, 7, 3, 2, 112, 119, 72, 221, 222, 70, 22, 126, 125, 210, 68, 1, 99, 39, 93, 84, 177, 62, 20, 77, 39, 253, 202, 60, 28, 235, 248, 105, 37, 41, 62, 176, 83, 123, 121, 78, 124, 241, 206, 185, 135, 2, 38, 43, 252, 129, 50, 149, 89, 76, 167, 203, 131, 225, 40, 119, 133, 179, 176, 211, 134, 111, 105, 122, 239, 92, 98, 71, 197, 156, 55, 209, 67, 41, 150, 246, 138, 64, 31 }, "JB", "$1$b7y9R.9V$ebzNktlD9JUdV4yxSLqSc0", new byte[] { 195, 13, 4, 7, 3, 2, 62, 32, 210, 120, 69, 210, 147, 84, 110, 210, 59, 1, 130, 196, 146, 168, 109, 200, 9, 235, 43, 196, 202, 116, 179, 69, 123, 3, 132, 55, 139, 233, 249, 80, 75, 190, 145, 230, 134, 27, 185, 70, 38, 189, 66, 241, 248, 246, 183, 193, 117, 19, 135, 206, 100, 58, 210, 209, 217, 216, 48, 219, 195, 181, 141, 22, 187, 152, 204, 215 }, null },
                    { new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b2"), new byte[] { 195, 13, 4, 7, 3, 2, 209, 184, 205, 80, 182, 99, 113, 120, 106, 210, 68, 1, 78, 95, 143, 73, 226, 8, 121, 147, 80, 38, 118, 190, 104, 82, 82, 215, 251, 20, 196, 59, 218, 148, 159, 97, 237, 248, 137, 43, 136, 23, 104, 226, 117, 0, 28, 76, 42, 165, 139, 4, 226, 28, 88, 39, 53, 122, 154, 141, 193, 200, 133, 140, 142, 128, 145, 238, 78, 114, 164, 59, 22, 76, 193, 29, 23, 245, 220 }, "Amy", "$1$jmU0uidB$A2AI39PsMMHmjjsTiUog10", new byte[] { 195, 13, 4, 7, 3, 2, 45, 83, 134, 137, 75, 143, 183, 25, 108, 210, 59, 1, 244, 35, 232, 127, 133, 143, 69, 30, 97, 125, 69, 144, 199, 251, 56, 86, 245, 44, 28, 28, 15, 138, 222, 107, 65, 171, 100, 248, 217, 244, 163, 14, 179, 173, 44, 164, 151, 199, 182, 213, 37, 246, 247, 102, 70, 219, 159, 132, 202, 50, 60, 7, 129, 89, 97, 222, 171, 158 }, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
