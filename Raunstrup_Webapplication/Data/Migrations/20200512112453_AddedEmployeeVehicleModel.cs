using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedEmployeeVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeVehicleModel",
                columns: table => new
                {
                    License_Plate = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Km_Price = table.Column<double>(nullable: false),
                    Day_Price = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ForeignKey1_Employee_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVehicleModel", x => x.License_Plate);
                    table.ForeignKey(
                        name: "FK_EmployeeVehicleModel_EmployeeModel_ForeignKey1_Employee_ID",
                        column: x => x.ForeignKey1_Employee_ID,
                        principalTable: "EmployeeModel",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVehicleModel_ForeignKey1_Employee_ID",
                table: "EmployeeVehicleModel",
                column: "ForeignKey1_Employee_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVehicleModel");
        }
    }
}
