using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AuditComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026916ef-3133-4e64-a843-6195f2739cdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10501f1b-cbec-4bda-aa52-8210702e5ea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bcc3d65-1252-42c5-ba0e-b94849d83408");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Audit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaac9f5e-9968-401d-8e86-6f0a4f892771", "f177df22-de41-4d0a-a0b7-a449f12de646", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "478d047e-ea8b-4923-b873-74930ddb0a2b", "996448ba-5ede-45ad-af41-9eb54c9a624e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2f51ed3-ea80-416d-bf65-dc8a5285750c", "df2a55dd-76b7-4b02-ba66-8d11412550b8", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478d047e-ea8b-4923-b873-74930ddb0a2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f51ed3-ea80-416d-bf65-dc8a5285750c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaac9f5e-9968-401d-8e86-6f0a4f892771");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Audit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10501f1b-cbec-4bda-aa52-8210702e5ea6", "bdabc4bc-f94d-44ad-9710-679432970a35", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "026916ef-3133-4e64-a843-6195f2739cdf", "ed49e65e-0e74-429d-8671-fa5fec7e8685", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bcc3d65-1252-42c5-ba0e-b94849d83408", "43c6d773-fb91-46d3-825a-219795be4f1f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
