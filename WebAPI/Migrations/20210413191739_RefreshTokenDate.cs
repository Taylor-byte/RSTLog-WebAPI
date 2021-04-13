using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RefreshTokenDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a99af442-2dcf-4b6a-a105-ff81e498766b", "adb89fbf-0983-427c-84bd-650f4e649fb1", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e29a6c50-9fec-4016-a3af-a2adb86bce0d", "93454c50-7cb2-4a32-81aa-a6ade6955059", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43d58e6b-e777-4e65-b470-10bfba74864b", "036c8f49-0908-41f1-8504-56d48666ceb4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43d58e6b-e777-4e65-b470-10bfba74864b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99af442-2dcf-4b6a-a105-ff81e498766b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29a6c50-9fec-4016-a3af-a2adb86bce0d");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
