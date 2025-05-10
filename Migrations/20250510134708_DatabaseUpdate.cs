using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10299399_PROG7311_GreenEnergy_POE.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Products",
                newName: "ProductDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDate",
                table: "Products",
                newName: "ProductDescription");
        }
    }
}
