using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class tagId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagToBlog_Tags_TageId",
                table: "TagToBlog");

            migrationBuilder.RenameColumn(
                name: "TageId",
                table: "TagToBlog",
                newName: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagToBlog_Tags_TagId",
                table: "TagToBlog",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagToBlog_Tags_TagId",
                table: "TagToBlog");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "TagToBlog",
                newName: "TageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagToBlog_Tags_TageId",
                table: "TagToBlog",
                column: "TageId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
