using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class updatemenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusInUserPanel",
                table: "Menu",
                newName: "StatusInUserMenu");

            migrationBuilder.RenameColumn(
                name: "StatusInAdminPanel",
                table: "Menu",
                newName: "StatusInAdminMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusInUserMenu",
                table: "Menu",
                newName: "StatusInUserPanel");

            migrationBuilder.RenameColumn(
                name: "StatusInAdminMenu",
                table: "Menu",
                newName: "StatusInAdminPanel");
        }
    }
}
