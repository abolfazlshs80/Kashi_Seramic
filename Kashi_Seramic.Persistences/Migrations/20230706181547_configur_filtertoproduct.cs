using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class configur_filtertoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterProductId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterId",
                table: "FilterToProduct");

            migrationBuilder.AddColumn<int>(
                name: "FilterProductId",
                table: "FilterToProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FilterToProduct_FilterProductId",
                table: "FilterToProduct",
                column: "FilterProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterToProduct_FilterProduct_FilterProductId",
                table: "FilterToProduct",
                column: "FilterProductId",
                principalTable: "FilterProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
