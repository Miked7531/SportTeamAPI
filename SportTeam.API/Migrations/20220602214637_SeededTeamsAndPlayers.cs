using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportTeam.API.Migrations
{
    public partial class SeededTeamsAndPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "Oakland", "Raiders" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 2, "Dallas", "Cowboys" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 3, "Charlotte", "Panthers" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "LastName", "TeamId" },
                values: new object[] { 1, "Bob", "Bobby", 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "LastName", "TeamId" },
                values: new object[] { 2, "Jack", "Samson", 2 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "LastName", "TeamId" },
                values: new object[] { 3, "Sam", "Winchester", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
