using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libAPI.Migrations
{
    /// <inheritdoc />
    public partial class isbm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBM",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBM",
                table: "Books",
                type: "varchar(13)",
                maxLength: 13,
                nullable: true);
        }
    }
}
