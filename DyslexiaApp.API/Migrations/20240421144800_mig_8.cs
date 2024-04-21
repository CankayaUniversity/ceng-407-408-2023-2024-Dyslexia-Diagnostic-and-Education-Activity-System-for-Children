using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Images_MainImageId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainImageId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Images_MainImageId",
                table: "Questions",
                column: "MainImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Images_MainImageId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainImageId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Images_MainImageId",
                table: "Questions",
                column: "MainImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
