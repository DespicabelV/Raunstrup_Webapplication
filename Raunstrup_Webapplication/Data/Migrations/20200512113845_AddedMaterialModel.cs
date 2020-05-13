using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedMaterialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Customer_Price",
                table: "ResourceModel",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Store_Price",
                table: "ResourceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ResourceModel",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_Price",
                table: "ResourceModel");

            migrationBuilder.DropColumn(
                name: "Store_Price",
                table: "ResourceModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ResourceModel");
        }
    }
}
