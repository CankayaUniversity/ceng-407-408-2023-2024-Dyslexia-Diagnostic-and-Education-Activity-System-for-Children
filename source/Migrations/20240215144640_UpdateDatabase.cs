using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaEduGameApp.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupportsId",
                table: "Sistems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SistemsId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sistems_SupportsId",
                table: "Sistems",
                column: "SupportsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SistemsId",
                table: "AspNetUsers",
                column: "SistemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sistems_SistemsId",
                table: "AspNetUsers",
                column: "SistemsId",
                principalTable: "Sistems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sistems_Supports_SupportsId",
                table: "Sistems",
                column: "SupportsId",
                principalTable: "Supports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sistems_SistemsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sistems_Supports_SupportsId",
                table: "Sistems");

            migrationBuilder.DropIndex(
                name: "IX_Sistems_SupportsId",
                table: "Sistems");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SistemsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupportsId",
                table: "Sistems");

            migrationBuilder.DropColumn(
                name: "SistemsId",
                table: "AspNetUsers");
        }
    }
}
