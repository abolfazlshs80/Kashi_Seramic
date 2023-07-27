using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class configur_filtertoproduct2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterId",
                table: "FilterToProduct");

            migrationBuilder.AddColumn<int>(
                name: "FilterProductId",
                table: "FilterToProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilterToProduct_FilterProductId",
                table: "FilterToProduct",
                column: "FilterProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterProductId",
                table: "FilterToProduct",
                column: "FilterProductId",
                principalTable: "FilterProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterToProduct_FilterValueProduct_FilterId",
                table: "FilterToProduct",
                column: "FilterId",
                principalTable: "FilterValueProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterProductId",
                table: "FilterToProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FilterToProduct_FilterValueProduct_FilterId",
                table: "FilterToProduct");

            migrationBuilder.DropIndex(
                name: "IX_FilterToProduct_FilterProductId",
                table: "FilterToProduct");

            migrationBuilder.DropColumn(
                name: "FilterProductId",
                table: "FilterToProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterId",
                table: "FilterToProduct",
                column: "FilterId",
                principalTable: "FilterProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
