using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTerminalProject.Migrations
{
    /// <inheritdoc />
    public partial class FixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "PrchaseCancelation",
                table: "Trips",
                newName: "PurchaseCancelation");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalIncome",
                table: "Trips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidPrice",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SeatCount",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalIncome",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PaidPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatCount",
                table: "Buses");

            migrationBuilder.RenameColumn(
                name: "PurchaseCancelation",
                table: "Trips",
                newName: "PrchaseCancelation");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
