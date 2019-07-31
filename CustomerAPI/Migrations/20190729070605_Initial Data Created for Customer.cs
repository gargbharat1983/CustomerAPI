using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerAPI.Migrations
{
    public partial class InitialDataCreatedforCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "Uncle", "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, "Jan", "Kirsten", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
