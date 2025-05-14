using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ST10299399_PROG7311_GreenEnergy_POE.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "EmployeeEmail", "EmployeeName", "EmployeePassword" },
                values: new object[] { "admin1@gmail.com", "Admin1", "admin1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeEmail", "EmployeeName", "EmployeePassword" },
                values: new object[,]
                {
                    { 2, "admin2@gmail.com", "Admin2", "admin2" },
                    { 3, "admin3@gmail.com", "Admin3", "admin3" },
                    { 4, "admin4@gmail.com", "Admin4", "admin4" },
                    { 5, "admin5@gmail.com", "Admin5", "admin5" }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerId", "FarmerEmail", "FarmerName", "FarmerPassword", "FarmerPhone", "FarmerSurname" },
                values: new object[,]
                {
                    { 1, "pieter@gmail.com", "Pieter", "pieter123", "1234567890", "Visser" },
                    { 2, "john@gmail.com", "John", "john123", "0647512222", "Porker" },
                    { 3, "jasper@gmail.com", "Jasper", "jasper123", "0761595555", "Rasper" },
                    { 4, "manie@gmail.com", "Manie", "manie123", "0541235678", "Libbok" },
                    { 5, "fanie@gmail.com", "Fanie", "fanie123", "0671592345", "Bosveld" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "EmployeeEmail", "EmployeeName", "EmployeePassword" },
                values: new object[] { "admin@gmail.com", "Admin", "admin123" });
        }
    }
}
