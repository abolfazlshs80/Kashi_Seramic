using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashi_Seramic.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class upsetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoryToBlogs_Blogs_BlogId",
                table: "categoryToBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_categoryToBlogs_Categories_CategoryId",
                table: "categoryToBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_orderSatus_Order_OrdersId",
                table: "orderSatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderSatus",
                table: "orderSatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryToBlogs",
                table: "categoryToBlogs");

            migrationBuilder.RenameTable(
                name: "orderSatus",
                newName: "OrderSatus");

            migrationBuilder.RenameTable(
                name: "categoryToBlogs",
                newName: "CategoryToBlogs");

            migrationBuilder.RenameIndex(
                name: "IX_orderSatus_OrdersId",
                table: "OrderSatus",
                newName: "IX_OrderSatus_OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_categoryToBlogs_BlogId",
                table: "CategoryToBlogs",
                newName: "IX_CategoryToBlogs_BlogId");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "TicketToReply",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "TicketGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "SiteSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "OrderSatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "OrderDetials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "FilterValueProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "FilterProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "FaqUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "CommentToProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "CommentToBlog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSatus",
                table: "OrderSatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToBlogs",
                table: "CategoryToBlogs",
                columns: new[] { "CategoryId", "BlogId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToBlogs_Blogs_BlogId",
                table: "CategoryToBlogs",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToBlogs_Categories_CategoryId",
                table: "CategoryToBlogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSatus_Order_OrdersId",
                table: "OrderSatus",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToBlogs_Blogs_BlogId",
                table: "CategoryToBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToBlogs_Categories_CategoryId",
                table: "CategoryToBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSatus_Order_OrdersId",
                table: "OrderSatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSatus",
                table: "OrderSatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToBlogs",
                table: "CategoryToBlogs");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "TicketToReply");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "TicketGroup");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "SiteSetting");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "OrderSatus");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "OrderDetials");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "FilterValueProduct");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "FilterProduct");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "FileManager");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "FaqUser");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "CommentToProduct");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "CommentToBlog");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "OrderSatus",
                newName: "orderSatus");

            migrationBuilder.RenameTable(
                name: "CategoryToBlogs",
                newName: "categoryToBlogs");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSatus_OrdersId",
                table: "orderSatus",
                newName: "IX_orderSatus_OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToBlogs_BlogId",
                table: "categoryToBlogs",
                newName: "IX_categoryToBlogs_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderSatus",
                table: "orderSatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryToBlogs",
                table: "categoryToBlogs",
                columns: new[] { "CategoryId", "BlogId" });

            migrationBuilder.AddForeignKey(
                name: "FK_categoryToBlogs_Blogs_BlogId",
                table: "categoryToBlogs",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoryToBlogs_Categories_CategoryId",
                table: "categoryToBlogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderSatus_Order_OrdersId",
                table: "orderSatus",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
