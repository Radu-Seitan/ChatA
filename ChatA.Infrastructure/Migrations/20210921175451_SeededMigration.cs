using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatA.Infrastructure.Migrations
{
    public partial class SeededMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { "google-oauth2|109835840698705157612", "raducseitan@gmail.com", "Radu Seitan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { "google-oauth2|101710427757368652279", "stefan.oproiu@amdaris.com", "Stefan Oproiu" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { "auth0|6149784cde45d300692a99b3", "radu.seitan@amdaris.com", "radu.seitan@amdaris.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "auth0|6149784cde45d300692a99b3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "google-oauth2|101710427757368652279");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "google-oauth2|109835840698705157612");
        }
    }
}
