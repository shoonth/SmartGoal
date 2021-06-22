using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGoalApp.Migrations
{
    public partial class AddMeasureMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasureMethod",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureMethod",
                table: "Tasks");
        }
    }
}
