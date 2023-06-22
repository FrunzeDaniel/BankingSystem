using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class addNewTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModel_Accounts_AccountId",
                table: "TransactionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModel_TransactionTypes_TransactionTypeId",
                table: "TransactionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionModel",
                table: "TransactionModel");

            migrationBuilder.RenameTable(
                name: "TransactionModel",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModel_TransactionTypeId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModel_AccountId",
                table: "Transactions",
                newName: "IX_Transactions_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerPurchaseModelId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerPurchaseModelId",
                table: "Transactions",
                column: "CustomerPurchaseModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CustomerPurchases_CustomerPurchaseModelId",
                table: "Transactions",
                column: "CustomerPurchaseModelId",
                principalTable: "CustomerPurchases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CustomerPurchases_CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomerPurchaseModelId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "TransactionModel");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "TransactionModel",
                newName: "IX_TransactionModel_TransactionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountId",
                table: "TransactionModel",
                newName: "IX_TransactionModel_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionModel",
                table: "TransactionModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModel_Accounts_AccountId",
                table: "TransactionModel",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModel_TransactionTypes_TransactionTypeId",
                table: "TransactionModel",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
