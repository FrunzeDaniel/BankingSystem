using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTableCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerModel_CustomerTypeModel_TypeId",
                table: "CustomerModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerTypeModel",
                table: "CustomerTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel");

            migrationBuilder.RenameTable(
                name: "CustomerTypeModel",
                newName: "CustomerTypes");

            migrationBuilder.RenameTable(
                name: "CustomerModel",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerModel_TypeId",
                table: "Customers",
                newName: "IX_Customers_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_TypeId",
                table: "Customers",
                column: "TypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_TypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerTypes",
                table: "CustomerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "CustomerTypes",
                newName: "CustomerTypeModel");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CustomerModel");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_TypeId",
                table: "CustomerModel",
                newName: "IX_CustomerModel_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerTypeModel",
                table: "CustomerTypeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerModel_CustomerTypeModel_TypeId",
                table: "CustomerModel",
                column: "TypeId",
                principalTable: "CustomerTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
