using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class ChangedStatusInOfferModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OfferModel",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "OfferModel",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
