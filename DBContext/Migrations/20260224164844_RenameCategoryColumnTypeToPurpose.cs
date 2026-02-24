using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeGastosAPI.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryColumnTypeToPurpose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Categories",
                newName: "Purpose");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "Categories",
                newName: "Type");
        }
    }
}
