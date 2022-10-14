using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCartService.Migrations
{
    public partial class shoppingCartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    shoppingcartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    purchaseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.shoppingcartId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    shoppingcartId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_ShoppingCarts_shoppingcartId",
                        column: x => x.shoppingcartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "shoppingcartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_shoppingcartId",
                table: "Items",
                column: "shoppingcartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
