using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileUpdateToken",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProfileUpdateTokenExpiry",
                table: "Users",
                newName: "VerificationCodeExpiry");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VerificationCodeExpiry",
                table: "Users",
                newName: "ProfileUpdateTokenExpiry");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUpdateToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
