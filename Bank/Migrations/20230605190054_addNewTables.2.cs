using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class addNewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Transactions",
                newName: "Other_Details");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "Amount_of_transaction");

            migrationBuilder.AlterColumn<string>(
                name: "Other_Details",
                table: "Transactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Other_Details",
                table: "Transactions",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "Amount_of_transaction",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
