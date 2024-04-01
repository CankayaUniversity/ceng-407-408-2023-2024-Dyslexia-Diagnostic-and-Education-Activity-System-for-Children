using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "Supports");

            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "Sistems");

            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "MatchingGames");

            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "GameSessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpent",
                table: "Supports",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpent",
                table: "Sistems",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpent",
                table: "MatchingGames",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpent",
                table: "GameSessions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
