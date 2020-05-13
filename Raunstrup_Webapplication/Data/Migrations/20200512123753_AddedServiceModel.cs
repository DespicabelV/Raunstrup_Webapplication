using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceModel",
                columns: table => new
                {
                    Service_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModel", x => x.Service_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceModel");
        }
    }
}
