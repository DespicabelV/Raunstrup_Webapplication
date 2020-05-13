using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class ChangesToRessourceModelAddedStoreAndCustomerPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ResourceModel");

            migrationBuilder.AlterColumn<double>(
                name: "Store_Price",
                table: "ResourceModel",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Customer_Price",
                table: "ResourceModel",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Store_Price",
                table: "ResourceModel",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Customer_Price",
                table: "ResourceModel",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ResourceModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
