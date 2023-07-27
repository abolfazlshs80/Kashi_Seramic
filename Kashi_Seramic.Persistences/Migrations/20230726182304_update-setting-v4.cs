using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class updatesettingv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeveloperLinkName",
                table: "SiteSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeveloperLinkName",
                table: "SiteSetting");
        }
    }
}
