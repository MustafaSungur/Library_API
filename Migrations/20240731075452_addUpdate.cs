using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageBook_Book_BookId",
                table: "LanguageBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageBook_Language_LanguageId",
                table: "LanguageBook");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBook_Book_BookId",
                table: "SubCategoryBook");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBook_SubCategory_SubCategoryId",
                table: "SubCategoryBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryBook",
                table: "SubCategoryBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageBook",
                table: "LanguageBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "SubCategoryBook",
                newName: "SubCategoryBooks");

            migrationBuilder.RenameTable(
                name: "LanguageBook",
                newName: "LanguageBooks");

            migrationBuilder.RenameTable(
                name: "AuthorBook",
                newName: "AuthorBooks");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryBook_BookId",
                table: "SubCategoryBooks",
                newName: "IX_SubCategoryBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageBook_BookId",
                table: "LanguageBooks",
                newName: "IX_LanguageBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryBooks",
                table: "SubCategoryBooks",
                columns: new[] { "SubCategoryId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageBooks",
                table: "LanguageBooks",
                columns: new[] { "LanguageId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageBooks_Book_BookId",
                table: "LanguageBooks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageBooks_Language_LanguageId",
                table: "LanguageBooks",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBooks_Book_BookId",
                table: "SubCategoryBooks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBooks_SubCategory_SubCategoryId",
                table: "SubCategoryBooks",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageBooks_Book_BookId",
                table: "LanguageBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageBooks_Language_LanguageId",
                table: "LanguageBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBooks_Book_BookId",
                table: "SubCategoryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBooks_SubCategory_SubCategoryId",
                table: "SubCategoryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryBooks",
                table: "SubCategoryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageBooks",
                table: "LanguageBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks");

            migrationBuilder.RenameTable(
                name: "SubCategoryBooks",
                newName: "SubCategoryBook");

            migrationBuilder.RenameTable(
                name: "LanguageBooks",
                newName: "LanguageBook");

            migrationBuilder.RenameTable(
                name: "AuthorBooks",
                newName: "AuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryBooks_BookId",
                table: "SubCategoryBook",
                newName: "IX_SubCategoryBook_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageBooks_BookId",
                table: "LanguageBook",
                newName: "IX_LanguageBook_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryBook",
                table: "SubCategoryBook",
                columns: new[] { "SubCategoryId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageBook",
                table: "LanguageBook",
                columns: new[] { "LanguageId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageBook_Book_BookId",
                table: "LanguageBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageBook_Language_LanguageId",
                table: "LanguageBook",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBook_Book_BookId",
                table: "SubCategoryBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBook_SubCategory_SubCategoryId",
                table: "SubCategoryBook",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
