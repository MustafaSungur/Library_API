using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Persons_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Persons_Id",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Genre_GenderId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_GenderId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_AddressId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Address_AddressId",
                table: "ApplicationUser",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Genre_GenderId",
                table: "ApplicationUser",
                column: "GenderId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ApplicationUser_Id",
                table: "Employees",
                column: "Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_ApplicationUser_Id",
                table: "Member",
                column: "Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Address_AddressId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Genre_GenderId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ApplicationUser_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_ApplicationUser_Id",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_GenderId",
                table: "Persons",
                newName: "IX_Persons_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_AddressId",
                table: "Persons",
                newName: "IX_Persons_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Persons_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Persons_Id",
                table: "Member",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Genre_GenderId",
                table: "Persons",
                column: "GenderId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
