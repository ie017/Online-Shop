using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    billingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    issueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.billingId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sum = table.Column<double>(type: "float", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderStatus = table.Column<int>(type: "int", nullable: false),
                    billingAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    deliveryAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Address_billingAddressId",
                        column: x => x.billingAddressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_Address_deliveryAddressId",
                        column: x => x.deliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_billingAddressId",
                table: "Order",
                column: "billingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryAddressId",
                table: "Order",
                column: "deliveryAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
