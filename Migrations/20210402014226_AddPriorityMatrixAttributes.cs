using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGoalApp.Migrations
{
    public partial class AddPriorityMatrixAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDateTime",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EffortLevel",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpactLevel",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImportanceLevel",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDateTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EffortLevel",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ImpactLevel",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ImportanceLevel",
                table: "Tasks");
        }
    }
}
