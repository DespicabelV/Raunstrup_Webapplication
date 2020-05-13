using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedEmployeeOfferModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferModel_CustomerModel_Customer_IDCostumor_Id",
                table: "OfferModel");

            migrationBuilder.DropIndex(
                name: "IX_OfferModel_Customer_IDCostumor_Id",
                table: "OfferModel");

            migrationBuilder.DropColumn(
                name: "Customer_IDCostumor_Id",
                table: "OfferModel");

            migrationBuilder.AddColumn<int>(
                name: "ForeignKey1_Costumor_Id",
                table: "OfferModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeOfferModel",
                columns: table => new
                {
                    EmployeeOffer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignKey1_Offer_ID = table.Column<int>(nullable: true),
                    ForeignKey2_Employee_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOfferModel", x => x.EmployeeOffer_ID);
                    table.ForeignKey(
                        name: "FK_EmployeeOfferModel_OfferModel_ForeignKey1_Offer_ID",
                        column: x => x.ForeignKey1_Offer_ID,
                        principalTable: "OfferModel",
                        principalColumn: "Offer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeOfferModel_EmployeeModel_ForeignKey2_Employee_ID",
                        column: x => x.ForeignKey2_Employee_ID,
                        principalTable: "EmployeeModel",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferModel_ForeignKey1_Costumor_Id",
                table: "OfferModel",
                column: "ForeignKey1_Costumor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOfferModel_ForeignKey1_Offer_ID",
                table: "EmployeeOfferModel",
                column: "ForeignKey1_Offer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOfferModel_ForeignKey2_Employee_ID",
                table: "EmployeeOfferModel",
                column: "ForeignKey2_Employee_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferModel_CustomerModel_ForeignKey1_Costumor_Id",
                table: "OfferModel",
                column: "ForeignKey1_Costumor_Id",
                principalTable: "CustomerModel",
                principalColumn: "Costumor_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferModel_CustomerModel_ForeignKey1_Costumor_Id",
                table: "OfferModel");

            migrationBuilder.DropTable(
                name: "EmployeeOfferModel");

            migrationBuilder.DropIndex(
                name: "IX_OfferModel_ForeignKey1_Costumor_Id",
                table: "OfferModel");

            migrationBuilder.DropColumn(
                name: "ForeignKey1_Costumor_Id",
                table: "OfferModel");

            migrationBuilder.AddColumn<int>(
                name: "Customer_IDCostumor_Id",
                table: "OfferModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferModel_Customer_IDCostumor_Id",
                table: "OfferModel",
                column: "Customer_IDCostumor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferModel_CustomerModel_Customer_IDCostumor_Id",
                table: "OfferModel",
                column: "Customer_IDCostumor_Id",
                principalTable: "CustomerModel",
                principalColumn: "Costumor_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
