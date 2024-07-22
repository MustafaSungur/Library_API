using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Book_BookId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_MemberId",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Stocks");

            migrationBuilder.AddColumn<string>(
                name: "ISBM",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "ISBM");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_MemberId",
                table: "BorrowHistories",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_StockId",
                table: "Book",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "ISBM",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_MemberId",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_Book_StockId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ISBM",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_MemberId",
                table: "BorrowHistories",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Book_BookId",
                table: "Stocks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
