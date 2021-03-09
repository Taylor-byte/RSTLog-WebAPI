using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FKCustToHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Hours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hours_CustomerId",
                table: "Hours",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Customer_CustomerId",
                table: "Hours",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Customer_CustomerId",
                table: "Hours");

            migrationBuilder.DropIndex(
                name: "IX_Hours_CustomerId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Hours");
        }
    }
}
