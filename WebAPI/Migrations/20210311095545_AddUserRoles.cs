using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
