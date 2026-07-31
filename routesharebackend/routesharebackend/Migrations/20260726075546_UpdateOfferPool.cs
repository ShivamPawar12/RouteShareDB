using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace routesharebackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfferPool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Price",
            //    table: "OfferPool");

            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "OfferPool",
                newName: "StartPoint");

            migrationBuilder.RenameColumn(
                name: "TravelDate",
                table: "OfferPool",
                newName: "TillDate");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "OfferPool",
                newName: "Route");

            migrationBuilder.RenameColumn(
                name: "SeatsAvailable",
                table: "OfferPool",
                newName: "AvailableSeats");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "OfferPool",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                table: "OfferPool",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "OfferPool",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "OfferPool",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "OfferPool",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OfferPool",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "OfferPool");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "OfferPool");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "OfferPool");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OfferPool");

            migrationBuilder.RenameColumn(
                name: "TillDate",
                table: "OfferPool",
                newName: "TravelDate");

            migrationBuilder.RenameColumn(
                name: "StartPoint",
                table: "OfferPool",
                newName: "VehicleType");

            migrationBuilder.RenameColumn(
                name: "Route",
                table: "OfferPool",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "OfferPool",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AvailableSeats",
                table: "OfferPool",
                newName: "SeatsAvailable");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "OfferPool",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OfferPool",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
