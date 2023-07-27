using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class updateUserrAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveByDefualt",
                table: "UserAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveByDefualt",
                table: "UserAddress");
        }
    }
}
