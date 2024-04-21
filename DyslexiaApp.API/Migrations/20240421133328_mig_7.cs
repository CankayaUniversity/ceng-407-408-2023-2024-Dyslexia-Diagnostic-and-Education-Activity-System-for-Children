using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrectAnswerIndex = table.Column<int>(type: "int", nullable: false),
                    MatchingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Images_MainImageId",
                        column: x => x.MainImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_MatchingGames_MatchingGameId",
                        column: x => x.MatchingGameId,
                        principalTable: "MatchingGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_QuestionId",
                table: "Images",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_MainImageId",
                table: "Questions",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_MatchingGameId",
                table: "Questions",
                column: "MatchingGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
