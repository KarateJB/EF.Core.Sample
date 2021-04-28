using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Dal.Migrations
{
    public partial class CreateMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.AddColumn<Guid>(
                name: "MetadataId",
                schema: "public",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SysMetadatas",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: true),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdateBy = table.Column<string>(type: "text", nullable: true),
                    RemoveOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RemoveBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMetadatas", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "SysMetadatas",
                columns: new[] { "Id", "CreateBy", "CreateOn", "IsDisabled", "RemoveBy", "RemoveOn", "UpdateBy", "UpdateOn" },
                values: new object[,]
                {
                    { new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86307"), "System", new DateTimeOffset(new DateTime(2021, 2, 1, 8, 56, 59, 734, DateTimeKind.Unspecified).AddTicks(6872), new TimeSpan(0, 0, 0, 0, 0)), false, null, null, null, null },
                    { new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b3"), "System", new DateTimeOffset(new DateTime(2021, 2, 1, 8, 56, 59, 736, DateTimeKind.Unspecified).AddTicks(8593), new TimeSpan(0, 0, 0, 0, 0)), false, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b2"),
                columns: new[] { "CardNo", "MetadataId", "Password", "Phone" },
                values: new object[] { new byte[] { 195, 13, 4, 7, 3, 2, 185, 116, 171, 210, 65, 88, 9, 96, 119, 210, 68, 1, 140, 2, 6, 253, 137, 171, 223, 173, 76, 252, 214, 133, 140, 237, 143, 17, 73, 28, 168, 140, 51, 9, 147, 85, 109, 20, 9, 148, 184, 27, 195, 244, 33, 106, 76, 184, 63, 228, 146, 124, 245, 152, 203, 42, 241, 79, 70, 171, 29, 184, 240, 152, 50, 95, 112, 239, 91, 9, 30, 183, 148, 218, 146, 122, 169, 187, 63 }, new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b3"), "$1$j7vxkhaB$/sOaey4kc1jVsQu/34WK/1", new byte[] { 195, 13, 4, 7, 3, 2, 208, 161, 146, 227, 253, 236, 76, 26, 103, 210, 59, 1, 137, 9, 240, 1, 188, 1, 153, 0, 116, 35, 141, 53, 120, 244, 49, 147, 187, 20, 196, 183, 21, 152, 224, 133, 244, 152, 237, 96, 70, 128, 101, 171, 128, 51, 122, 182, 174, 81, 133, 64, 188, 45, 225, 249, 124, 254, 218, 42, 205, 218, 243, 248, 245, 98, 251, 206, 105, 210 } });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86306"),
                columns: new[] { "CardNo", "MetadataId", "Password", "Phone" },
                values: new object[] { new byte[] { 195, 13, 4, 7, 3, 2, 202, 116, 76, 44, 156, 149, 28, 175, 96, 210, 68, 1, 50, 102, 115, 20, 41, 166, 24, 17, 206, 33, 13, 179, 165, 161, 51, 69, 201, 63, 143, 56, 98, 26, 156, 12, 13, 68, 157, 18, 211, 78, 200, 240, 221, 177, 153, 48, 11, 221, 18, 119, 45, 200, 63, 222, 69, 96, 82, 87, 12, 130, 6, 58, 188, 183, 223, 112, 246, 114, 98, 137, 14, 7, 160, 197, 64, 124, 122 }, new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86307"), "$1$RTK9B5TQ$RlbKXBRdkF8BO.vhIax5m0", new byte[] { 195, 13, 4, 7, 3, 2, 246, 98, 155, 74, 88, 124, 5, 83, 123, 210, 59, 1, 28, 204, 188, 170, 241, 156, 60, 235, 64, 16, 201, 72, 2, 55, 183, 158, 212, 182, 4, 229, 114, 201, 234, 151, 159, 1, 202, 234, 165, 192, 101, 60, 137, 114, 208, 249, 145, 163, 52, 140, 49, 212, 190, 150, 208, 31, 11, 6, 152, 195, 207, 163, 249, 149, 244, 30, 179, 6 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MetadataId",
                schema: "public",
                table: "Users",
                column: "MetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SysMetadatas_MetadataId",
                schema: "public",
                table: "Users",
                column: "MetadataId",
                principalSchema: "system",
                principalTable: "SysMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SysMetadatas_MetadataId",
                schema: "public",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SysMetadatas",
                schema: "system");

            migrationBuilder.DropIndex(
                name: "IX_Users_MetadataId",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MetadataId",
                schema: "public",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b2"),
                columns: new[] { "CardNo", "Password", "Phone" },
                values: new object[] { new byte[] { 195, 13, 4, 7, 3, 2, 61, 153, 37, 19, 149, 32, 232, 216, 103, 210, 68, 1, 183, 88, 124, 169, 115, 106, 109, 211, 197, 186, 139, 173, 204, 157, 163, 144, 160, 204, 68, 206, 225, 84, 242, 145, 224, 79, 56, 231, 130, 14, 155, 125, 181, 110, 106, 76, 56, 7, 84, 111, 16, 254, 109, 25, 84, 213, 187, 37, 60, 65, 215, 232, 186, 95, 72, 68, 33, 115, 22, 9, 169, 113, 231, 251, 178, 206, 87 }, "$1$lg4pQaQZ$g2o0WCy0N85qb2s5nUemE.", new byte[] { 195, 13, 4, 7, 3, 2, 26, 240, 221, 249, 45, 118, 117, 37, 98, 210, 59, 1, 139, 64, 155, 58, 113, 142, 23, 57, 121, 48, 62, 26, 55, 126, 106, 12, 159, 148, 223, 234, 132, 178, 77, 92, 160, 7, 43, 117, 119, 162, 140, 31, 4, 174, 124, 225, 60, 7, 142, 171, 120, 250, 13, 101, 159, 144, 50, 110, 187, 18, 112, 36, 64, 207, 60, 0, 104, 97 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86306"),
                columns: new[] { "CardNo", "Password", "Phone" },
                values: new object[] { new byte[] { 195, 13, 4, 7, 3, 2, 17, 25, 92, 174, 239, 39, 59, 191, 123, 210, 68, 1, 144, 31, 100, 130, 54, 45, 39, 206, 132, 235, 226, 92, 22, 218, 180, 0, 131, 178, 68, 243, 124, 151, 22, 132, 188, 137, 122, 239, 232, 29, 192, 126, 34, 158, 154, 31, 103, 155, 81, 10, 37, 251, 63, 211, 185, 230, 131, 120, 4, 179, 126, 140, 1, 154, 80, 222, 50, 210, 87, 150, 201, 131, 185, 107, 187, 23, 18 }, "$1$dVjkVboV$HK6mFOzqE.arAMIKVBfZV/", new byte[] { 195, 13, 4, 7, 3, 2, 247, 174, 241, 144, 186, 76, 68, 245, 122, 210, 59, 1, 129, 188, 152, 252, 77, 99, 88, 64, 99, 149, 220, 150, 176, 250, 99, 152, 147, 29, 224, 116, 146, 209, 168, 101, 152, 176, 213, 7, 142, 144, 102, 252, 5, 255, 202, 211, 11, 211, 146, 80, 204, 155, 92, 94, 79, 243, 150, 246, 193, 87, 174, 102, 197, 56, 108, 97, 87, 236 } });
        }
    }
}
