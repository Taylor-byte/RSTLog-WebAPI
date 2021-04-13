using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RefreshTokenUserFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35ec2199-6650-4180-a3dc-92c20f35017d", "5f316adc-6f4a-48eb-9c01-9dda55016455", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fb4a6cb-3469-42f8-8dc1-9cd57bc0a25a", "53d6c95a-7d5b-4fe7-82c8-ff01099d35bd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7629e832-3a1a-4a4e-95d3-3f59d28aea6b", "3635d873-fa60-4d1e-99d5-8edf472dfc7a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fb4a6cb-3469-42f8-8dc1-9cd57bc0a25a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ec2199-6650-4180-a3dc-92c20f35017d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7629e832-3a1a-4a4e-95d3-3f59d28aea6b");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
