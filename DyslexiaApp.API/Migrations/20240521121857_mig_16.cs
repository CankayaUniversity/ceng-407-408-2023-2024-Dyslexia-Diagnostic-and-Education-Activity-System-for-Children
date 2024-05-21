using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_NavigationGames_NavigationGameId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_NavigationGameId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "NavigationGameId",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "NavigationGameId",
                table: "NavigationGameQuestions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NavigationGameQuestions_NavigationGameId",
                table: "NavigationGameQuestions",
                column: "NavigationGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationGameQuestions_NavigationGames_NavigationGameId",
                table: "NavigationGameQuestions",
                column: "NavigationGameId",
                principalTable: "NavigationGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavigationGameQuestions_NavigationGames_NavigationGameId",
                table: "NavigationGameQuestions");

            migrationBuilder.DropIndex(
                name: "IX_NavigationGameQuestions_NavigationGameId",
                table: "NavigationGameQuestions");

            migrationBuilder.DropColumn(
                name: "NavigationGameId",
                table: "NavigationGameQuestions");

            migrationBuilder.AddColumn<Guid>(
                name: "NavigationGameId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NavigationGameId",
                table: "Questions",
                column: "NavigationGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_NavigationGames_NavigationGameId",
                table: "Questions",
                column: "NavigationGameId",
                principalTable: "NavigationGames",
                principalColumn: "Id");
        }
    }
}
