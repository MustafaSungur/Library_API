using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedStatusAtBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StockId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "ISBM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StockId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Stocks_StockId",
                table: "Book",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "ISBM",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
