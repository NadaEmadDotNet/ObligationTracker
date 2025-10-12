using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyofclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obligations_Client_clientId",
                table: "Obligations");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Obligations",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Obligations_clientId",
                table: "Obligations",
                newName: "IX_Obligations_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obligations_Client_ClientId",
                table: "Obligations",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obligations_Client_ClientId",
                table: "Obligations");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Obligations",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Obligations_ClientId",
                table: "Obligations",
                newName: "IX_Obligations_clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obligations_Client_clientId",
                table: "Obligations",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
