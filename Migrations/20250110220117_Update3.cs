using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    ID_WishList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.ID_WishList);
                });

            migrationBuilder.CreateTable(
                name: "WishList_Book",
                columns: table => new
                {
                    ID_WishList_Produs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_WishList = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList_Book", x => x.ID_WishList_Produs);
                    table.ForeignKey(
                        name: "FK_WishList_Book_Books_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN");
                    table.ForeignKey(
                        name: "FK_WishList_Book_WishList_ID_WishList",
                        column: x => x.ID_WishList,
                        principalTable: "WishList",
                        principalColumn: "ID_WishList",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_Book_ID_WishList",
                table: "WishList_Book",
                column: "ID_WishList");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_Book_ISBN",
                table: "WishList_Book",
                column: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishList_Book");

            migrationBuilder.DropTable(
                name: "WishList");
        }
    }
}
