using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTerminalProject.Migrations
{
    /// <inheritdoc />
    public partial class FieldChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalIncome",
                table: "Trips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalIncome",
                table: "Trips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
