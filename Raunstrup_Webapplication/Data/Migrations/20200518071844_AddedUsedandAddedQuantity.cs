using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedUsedandAddedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Added_Quantity",
                table: "ServiceLineModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Used_Quantity",
                table: "ServiceLineModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoursWorked",
                table: "EmployeeOfferModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added_Quantity",
                table: "ServiceLineModel");

            migrationBuilder.DropColumn(
                name: "Used_Quantity",
                table: "ServiceLineModel");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "EmployeeOfferModel");
        }
    }
}
