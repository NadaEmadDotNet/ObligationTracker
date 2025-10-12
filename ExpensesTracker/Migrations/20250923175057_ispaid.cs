using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
    /// <inheritdoc />
    public partial class ispaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obligations_AspNetUsers_userId",
                table: "Obligations");

            migrationBuilder.DropIndex(
                name: "IX_Obligations_userId",
                table: "Obligations");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Obligations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsPAid",
                table: "Obligations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPAid",
                table: "Obligations");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Obligations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
