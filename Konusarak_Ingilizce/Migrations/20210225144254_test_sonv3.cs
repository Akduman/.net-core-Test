using Microsoft.EntityFrameworkCore.Migrations;

namespace Konusarak_Ingilizce.Migrations
{
    public partial class test_sonv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "User_Name",
                value: "test_admin_name15");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "User_Name",
                value: "test_admin_name22");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "User_Name",
                value: "test_admin_name19");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "User_Name",
                value: "test_admin_name25");
        }
    }
}
