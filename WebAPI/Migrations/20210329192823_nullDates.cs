using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class nullDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "326b925d-962e-4e95-a81e-a3035ae299b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906f0118-f7e9-4df4-903d-92be2674d7b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4f080ec-e3ff-42f3-91e4-b749713efeee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Invoiced",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "InvoicedDate",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbc7934e-8737-4e6c-93d5-57eac28078ab", "38fc8063-1553-4738-98ff-01b1c0b44a4c", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d7b6ac3-ae81-4c19-b106-383c8f5e3494", "49f64619-865a-4f04-bbbc-63e40e9a546a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9463b9ad-eb5c-41b3-a473-c745f261ccf6", "607c0128-f1cf-4870-baaa-cf606c8f49af", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d7b6ac3-ae81-4c19-b106-383c8f5e3494");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9463b9ad-eb5c-41b3-a473-c745f261ccf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbc7934e-8737-4e6c-93d5-57eac28078ab");

            migrationBuilder.DropColumn(
                name: "InvoicedDate",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Invoiced",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4f080ec-e3ff-42f3-91e4-b749713efeee", "255e78a2-84fe-41b4-86fb-6d654ef640b7", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "326b925d-962e-4e95-a81e-a3035ae299b6", "dcd57efd-be40-4fae-883b-f8864d2f81de", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "906f0118-f7e9-4df4-903d-92be2674d7b1", "ee425bf9-7bfb-402b-a3af-70f585061796", "Administrator", "ADMINISTRATOR" });
        }
    }
}
