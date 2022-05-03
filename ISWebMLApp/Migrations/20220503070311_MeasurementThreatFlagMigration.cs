using Microsoft.EntityFrameworkCore.Migrations;

namespace ISWebMLApp.Migrations
{
    public partial class MeasurementThreatFlagMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ThreatFlag",
                table: "Measurements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreatFlag",
                table: "Measurements");
        }
    }
}
