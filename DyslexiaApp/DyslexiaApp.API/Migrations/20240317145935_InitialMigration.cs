using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DyslexiaDiagnosis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestResults = table.Column<int>(type: "int", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyslexiaDiagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyslexiaDiagnosis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationalGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sistems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    NavigationElements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sistems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NavigationGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    DyslexiaDiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavigationGames_DyslexiaDiagnosis_DyslexiaDiagnosisId",
                        column: x => x.DyslexiaDiagnosisId,
                        principalTable: "DyslexiaDiagnosis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchingGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    DyslexiaDiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationalGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingGames_DyslexiaDiagnosis_DyslexiaDiagnosisId",
                        column: x => x.DyslexiaDiagnosisId,
                        principalTable: "DyslexiaDiagnosis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchingGames_EducationalGames_EducationalGameId",
                        column: x => x.EducationalGameId,
                        principalTable: "EducationalGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    FAQs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactString = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SistemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supports_Sistems_SistemId",
                        column: x => x.SistemId,
                        principalTable: "Sistems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationalGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionScore = table.Column<int>(type: "int", nullable: false),
                    MatchingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessions_EducationalGames_EducationalGameId",
                        column: x => x.EducationalGameId,
                        principalTable: "EducationalGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameSessions_MatchingGames_MatchingGameId",
                        column: x => x.MatchingGameId,
                        principalTable: "MatchingGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DyslexiaDiagnosis_UserId",
                table: "DyslexiaDiagnosis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalGames_UserId",
                table: "EducationalGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_EducationalGameId",
                table: "GameSessions",
                column: "EducationalGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_MatchingGameId",
                table: "GameSessions",
                column: "MatchingGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_UserId",
                table: "GameSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingGames_DyslexiaDiagnosisId",
                table: "MatchingGames",
                column: "DyslexiaDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingGames_EducationalGameId",
                table: "MatchingGames",
                column: "EducationalGameId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationGames_DyslexiaDiagnosisId",
                table: "NavigationGames",
                column: "DyslexiaDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Sistems_UserId",
                table: "Sistems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_SistemId",
                table: "Supports",
                column: "SistemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropTable(
                name: "NavigationGames");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "MatchingGames");

            migrationBuilder.DropTable(
                name: "Sistems");

            migrationBuilder.DropTable(
                name: "DyslexiaDiagnosis");

            migrationBuilder.DropTable(
                name: "EducationalGames");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
