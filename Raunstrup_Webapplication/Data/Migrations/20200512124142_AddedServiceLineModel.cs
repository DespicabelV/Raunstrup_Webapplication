using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedServiceLineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceLineModel",
                columns: table => new
                {
                    Service_Line_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignKey1_Res_ID = table.Column<int>(nullable: true),
                    Resource_Quantity = table.Column<int>(nullable: false),
                    ForeignKey2_Service_ID = table.Column<int>(nullable: true),
                    ForeignKey3_Offer_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLineModel", x => x.Service_Line_ID);
                    table.ForeignKey(
                        name: "FK_ServiceLineModel_ResourceModel_ForeignKey1_Res_ID",
                        column: x => x.ForeignKey1_Res_ID,
                        principalTable: "ResourceModel",
                        principalColumn: "Res_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceLineModel_ServiceModel_ForeignKey2_Service_ID",
                        column: x => x.ForeignKey2_Service_ID,
                        principalTable: "ServiceModel",
                        principalColumn: "Service_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceLineModel_OfferModel_ForeignKey3_Offer_ID",
                        column: x => x.ForeignKey3_Offer_ID,
                        principalTable: "OfferModel",
                        principalColumn: "Offer_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLineModel_ForeignKey1_Res_ID",
                table: "ServiceLineModel",
                column: "ForeignKey1_Res_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLineModel_ForeignKey2_Service_ID",
                table: "ServiceLineModel",
                column: "ForeignKey2_Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLineModel_ForeignKey3_Offer_ID",
                table: "ServiceLineModel",
                column: "ForeignKey3_Offer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceLineModel");
        }
    }
}
