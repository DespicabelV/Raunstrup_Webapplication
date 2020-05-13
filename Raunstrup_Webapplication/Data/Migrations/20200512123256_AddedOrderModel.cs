using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    Order_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignKey1_Offer_ID = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ForeignKey2_Costumor_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_OrderModel_OfferModel_ForeignKey1_Offer_ID",
                        column: x => x.ForeignKey1_Offer_ID,
                        principalTable: "OfferModel",
                        principalColumn: "Offer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderModel_CustomerModel_ForeignKey2_Costumor_Id",
                        column: x => x.ForeignKey2_Costumor_Id,
                        principalTable: "CustomerModel",
                        principalColumn: "Costumor_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_ForeignKey1_Offer_ID",
                table: "OrderModel",
                column: "ForeignKey1_Offer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_ForeignKey2_Costumor_Id",
                table: "OrderModel",
                column: "ForeignKey2_Costumor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderModel");
        }
    }
}
