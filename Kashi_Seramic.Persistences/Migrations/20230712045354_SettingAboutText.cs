using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class SettingAboutText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "AboutText",
                table: "SiteSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutText",
                table: "SiteSetting");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
