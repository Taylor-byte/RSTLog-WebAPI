using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AuditEmployeeIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audit_Employee_EmployeeId",
                table: "Audit");

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

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Audit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cfad2b8-c300-46f6-b80d-967c45a5c889", "0c3752b2-8d47-462d-bff7-dc0a69aed196", "Lookup", "LOOKUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbd2c543-01d1-48dc-bcde-a27b2e24b094", "d81a75f4-c3ab-4064-8f92-f3f2c7249311", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "317c3ece-e9d6-47a7-beef-18bc4968899e", "8f281525-e6e6-4647-a9e4-34e908511ab0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Employee_EmployeeId",
                table: "Audit",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audit_Employee_EmployeeId",
                table: "Audit");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "317c3ece-e9d6-47a7-beef-18bc4968899e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfad2b8-c300-46f6-b80d-967c45a5c889");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbd2c543-01d1-48dc-bcde-a27b2e24b094");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Audit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Employee_EmployeeId",
                table: "Audit",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
