using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class fitertoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilterToProduct",
                columns: table => new
                {
                    FilterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FilterProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterToProduct", x => new { x.FilterId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FilterToProduct_FilterProduct_FilterProductId",
                        column: x => x.FilterProductId,
                        principalTable: "FilterProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterToProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilterToProduct_FilterProductId",
                table: "FilterToProduct",
                column: "FilterProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterToProduct_ProductId",
                table: "FilterToProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterToProduct");
        }
    }
}
