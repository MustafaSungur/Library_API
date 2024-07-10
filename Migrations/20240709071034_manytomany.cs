using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLanguage");

            migrationBuilder.DropTable(
                name: "BookSubCategory");

            migrationBuilder.CreateTable(
                name: "LanguageBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageBooks", x => new { x.LanguageId, x.BookId });
                    table.ForeignKey(
                        name: "FK_LanguageBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageBooks_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryBooks", x => new { x.SubCategoryId, x.BookId });
                    table.ForeignKey(
                        name: "FK_SubCategoryBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryBooks_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageBooks_BookId",
                table: "LanguageBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryBooks_BookId",
                table: "SubCategoryBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageBooks");

            migrationBuilder.DropTable(
                name: "SubCategoryBooks");

            migrationBuilder.CreateTable(
                name: "BookLanguage",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    LanguagesCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLanguage", x => new { x.BooksId, x.LanguagesCode });
                    table.ForeignKey(
                        name: "FK_BookLanguage_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLanguage_Languages_LanguagesCode",
                        column: x => x.LanguagesCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSubCategory",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriesId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubCategory", x => new { x.BooksId, x.SubCategoriesId });
                    table.ForeignKey(
                        name: "FK_BookSubCategory_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubCategory_SubCategories_SubCategoriesId",
                        column: x => x.SubCategoriesId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLanguage_LanguagesCode",
                table: "BookLanguage",
                column: "LanguagesCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubCategory_SubCategoriesId",
                table: "BookSubCategory",
                column: "SubCategoriesId");
        }
    }
}
