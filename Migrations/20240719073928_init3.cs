using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeTitle_TitleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Persons_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Shift_ShiftId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Genre_GenderId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_TitleId",
                table: "Employees",
                newName: "IX_Employees_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ShiftId",
                table: "Employees",
                newName: "IX_Employees_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AlterColumn<short>(
                name: "GenderId",
                table: "Persons",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTitle_TitleId",
                table: "Employees",
                column: "TitleId",
                principalTable: "EmployeeTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Persons_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Shift_ShiftId",
                table: "Employees",
                column: "ShiftId",
                principalTable: "Shift",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTitle_TitleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Persons_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Shift_ShiftId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Genre_GenderId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_TitleId",
                table: "Employee",
                newName: "IX_Employee_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ShiftId",
                table: "Employee",
                newName: "IX_Employee_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AlterColumn<short>(
                name: "GenderId",
                table: "Persons",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeTitle_TitleId",
                table: "Employee",
                column: "TitleId",
                principalTable: "EmployeeTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Persons_Id",
                table: "Employee",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Shift_ShiftId",
                table: "Employee",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Genre_GenderId",
                table: "Persons",
                column: "GenderId",
                principalTable: "Genre",
                principalColumn: "Id");
        }
    }
}
