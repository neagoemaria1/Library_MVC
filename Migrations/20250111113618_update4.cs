using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Book_Books_ISBN",
                table: "WishList_Book");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Book_WishList_ID_WishList",
                table: "WishList_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList_Book",
                table: "WishList_Book");

            migrationBuilder.RenameTable(
                name: "WishList_Book",
                newName: "WishListBooks");

            migrationBuilder.RenameColumn(
                name: "ID_WishList_Produs",
                table: "WishListBooks",
                newName: "ID_WishList_Book");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_Book_ISBN",
                table: "WishListBooks",
                newName: "IX_WishListBooks_ISBN");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_Book_ID_WishList",
                table: "WishListBooks",
                newName: "IX_WishListBooks_ID_WishList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListBooks",
                table: "WishListBooks",
                column: "ID_WishList_Book");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListBooks_Books_ISBN",
                table: "WishListBooks",
                column: "ISBN",
                principalTable: "Books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListBooks_WishList_ID_WishList",
                table: "WishListBooks",
                column: "ID_WishList",
                principalTable: "WishList",
                principalColumn: "ID_WishList",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListBooks_Books_ISBN",
                table: "WishListBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListBooks_WishList_ID_WishList",
                table: "WishListBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListBooks",
                table: "WishListBooks");

            migrationBuilder.RenameTable(
                name: "WishListBooks",
                newName: "WishList_Book");

            migrationBuilder.RenameColumn(
                name: "ID_WishList_Book",
                table: "WishList_Book",
                newName: "ID_WishList_Produs");

            migrationBuilder.RenameIndex(
                name: "IX_WishListBooks_ISBN",
                table: "WishList_Book",
                newName: "IX_WishList_Book_ISBN");

            migrationBuilder.RenameIndex(
                name: "IX_WishListBooks_ID_WishList",
                table: "WishList_Book",
                newName: "IX_WishList_Book_ID_WishList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList_Book",
                table: "WishList_Book",
                column: "ID_WishList_Produs");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Book_Books_ISBN",
                table: "WishList_Book",
                column: "ISBN",
                principalTable: "Books",
                principalColumn: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Book_WishList_ID_WishList",
                table: "WishList_Book",
                column: "ID_WishList",
                principalTable: "WishList",
                principalColumn: "ID_WishList",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
