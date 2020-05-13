using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedOfferModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferModel",
                columns: table => new
                {
                    Offer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offer_Title = table.Column<string>(nullable: true),
                    Start_date = table.Column<DateTime>(nullable: false),
                    End_Date = table.Column<DateTime>(nullable: false),
                    Offer_Price = table.Column<double>(nullable: false),
                    Customer_IDCostumor_Id = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferModel", x => x.Offer_ID);
                    table.ForeignKey(
                        name: "FK_OfferModel_CustomerModel_Customer_IDCostumor_Id",
                        column: x => x.Customer_IDCostumor_Id,
                        principalTable: "CustomerModel",
                        principalColumn: "Costumor_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferModel_Customer_IDCostumor_Id",
                table: "OfferModel",
                column: "Customer_IDCostumor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferModel");
        }
    }
}
