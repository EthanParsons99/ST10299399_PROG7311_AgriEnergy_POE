using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10299399_PROG7311_GreenEnergy_POE.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdateFarmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FarmerEmail",
                table: "Farmers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FarmerPhone",
                table: "Farmers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FarmerSurname",
                table: "Farmers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmerEmail",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmerPhone",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmerSurname",
                table: "Farmers");
        }
    }
}
