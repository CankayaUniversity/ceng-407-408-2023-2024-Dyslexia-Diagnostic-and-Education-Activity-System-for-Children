using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NavigationGameId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NavigationGameId",
                table: "GameSessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NavigationGameId",
                table: "Questions",
                column: "NavigationGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_NavigationGameId",
                table: "GameSessions",
                column: "NavigationGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_NavigationGames_NavigationGameId",
                table: "GameSessions",
                column: "NavigationGameId",
                principalTable: "NavigationGames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_NavigationGames_NavigationGameId",
                table: "Questions",
                column: "NavigationGameId",
                principalTable: "NavigationGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_NavigationGames_NavigationGameId",
                table: "GameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_NavigationGames_NavigationGameId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_NavigationGameId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_GameSessions_NavigationGameId",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "NavigationGameId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "NavigationGameId",
                table: "GameSessions");
        }
    }
}
