using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Member_MemberId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Employees_EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.AddColumn<string>(
                name: "BorrowingEmployeeId",
                table: "BorrowHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LendingEmployeeId",
                table: "BorrowHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_BorrowingEmployeeId",
                table: "BorrowHistories",
                column: "BorrowingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_LendingEmployeeId",
                table: "BorrowHistories",
                column: "LendingEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Member_MemberId",
                table: "BorrowBooks",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Employees_BorrowingEmployeeId",
                table: "BorrowHistories",
                column: "BorrowingEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Employees_LendingEmployeeId",
                table: "BorrowHistories",
                column: "LendingEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Member_MemberId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Employees_BorrowingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Employees_LendingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_BorrowingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_LendingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "BorrowingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "LendingEmployeeId",
                table: "BorrowHistories");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "BorrowHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_EmployeeId",
                table: "BorrowHistories",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Member_MemberId",
                table: "BorrowBooks",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Employees_EmployeeId",
                table: "BorrowHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
