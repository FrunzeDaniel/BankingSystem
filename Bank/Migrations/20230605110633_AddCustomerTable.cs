using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Customer_phone = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Customer_email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Date_became_customer = table.Column<DateOnly>(type: "date", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerModel_CustomerTypeModel_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CustomerTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModel_TypeId",
                table: "CustomerModel",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerModel");
        }
    }
}
