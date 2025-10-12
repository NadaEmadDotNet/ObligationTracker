using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IaPaid",
                table: "Obligations");

            migrationBuilder.AddColumn<double>(
                name: "PaidAmount",
                table: "Obligations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Obligations");

            migrationBuilder.AddColumn<bool>(
                name: "IaPaid",
                table: "Obligations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
