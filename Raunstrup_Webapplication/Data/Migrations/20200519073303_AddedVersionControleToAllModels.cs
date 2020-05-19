using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup_Webapplication.Data.Migrations
{
    public partial class AddedVersionControleToAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceLineModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ResourceModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OrderModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OfferModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EmployeeVehicleModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EmployeeOfferModel",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EmployeeModel",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceLineModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ResourceModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OfferModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EmployeeVehicleModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EmployeeOfferModel");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EmployeeModel");
        }
    }
}
