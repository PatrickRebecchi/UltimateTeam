using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltimanteTeam.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Escudo",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escudo",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Times");
        }
    }
}
