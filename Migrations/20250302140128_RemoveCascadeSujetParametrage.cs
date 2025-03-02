using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCascadeSujetParametrage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen",
                column: "SujetId",
                principalTable: "Sujets",
                principalColumn: "SujetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen",
                column: "SujetId",
                principalTable: "Sujets",
                principalColumn: "SujetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
