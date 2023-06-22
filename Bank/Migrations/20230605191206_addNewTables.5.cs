using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class addNewTables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CustomerPurchases_CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PurchaseId",
                table: "Transactions",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CustomerPurchases_PurchaseId",
                table: "Transactions",
                column: "PurchaseId",
                principalTable: "CustomerPurchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CustomerPurchases_PurchaseId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PurchaseId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CustomerPurchaseModelId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerPurchaseModelId",
                table: "Transactions",
                column: "CustomerPurchaseModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CustomerPurchases_CustomerPurchaseModelId",
                table: "Transactions",
                column: "CustomerPurchaseModelId",
                principalTable: "CustomerPurchases",
                principalColumn: "Id");
        }
    }
}
