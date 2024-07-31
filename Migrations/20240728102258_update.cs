using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Member_MemberId",
                table: "BorrowHistories");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "BorrowHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "BorrowHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedMemberIds",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRating",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_EmployeeId",
                table: "BorrowHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistories_MemberId1",
                table: "BorrowHistories",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_EmployeeId",
                table: "BorrowBooks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_EmployeeId1",
                table: "BorrowBooks",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Employees_EmployeeId",
                table: "BorrowBooks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Employees_EmployeeId1",
                table: "BorrowBooks",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Employees_EmployeeId",
                table: "BorrowHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Member_MemberId",
                table: "BorrowHistories",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Member_MemberId1",
                table: "BorrowHistories",
                column: "MemberId1",
                principalTable: "Member",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Employees_EmployeeId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Employees_EmployeeId1",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Employees_EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Member_MemberId",
                table: "BorrowHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Member_MemberId1",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistories_MemberId1",
                table: "BorrowHistories");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_EmployeeId",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_EmployeeId1",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "BorrowHistories");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "RatedMemberIds",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Member_MemberId",
                table: "BorrowHistories",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
