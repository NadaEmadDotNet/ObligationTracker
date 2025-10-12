using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Obligations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Obligations_userId",
                table: "Obligations",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obligations_AspNetUsers_userId",
                table: "Obligations",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obligations_AspNetUsers_userId",
                table: "Obligations");

            migrationBuilder.DropIndex(
                name: "IX_Obligations_userId",
                table: "Obligations");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Obligations");
        }
    }
}
