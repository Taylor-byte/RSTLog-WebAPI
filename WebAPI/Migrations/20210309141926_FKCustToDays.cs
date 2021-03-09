using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FKCustToDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Days_CustomerId",
                table: "Days",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Customer_CustomerId",
                table: "Days",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Customer_CustomerId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_CustomerId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Days");
        }
    }
}
