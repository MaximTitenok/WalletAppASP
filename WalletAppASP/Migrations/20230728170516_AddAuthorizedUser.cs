using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppASP.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorizedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorizedUserId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AuthorizedUserId",
                table: "Transactions",
                column: "AuthorizedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AuthorizedUserId",
                table: "Transactions",
                column: "AuthorizedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AuthorizedUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AuthorizedUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AuthorizedUserId",
                table: "Transactions");
        }
    }
}
