using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedParametrageExamenToSujetRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SujetId",
                table: "ParametragesExamen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParametragesExamen_SujetId",
                table: "ParametragesExamen",
                column: "SujetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen",
                column: "SujetId",
                principalTable: "Sujets",
                principalColumn: "SujetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParametragesExamen_Sujets_SujetId",
                table: "ParametragesExamen");

            migrationBuilder.DropIndex(
                name: "IX_ParametragesExamen_SujetId",
                table: "ParametragesExamen");

            migrationBuilder.DropColumn(
                name: "SujetId",
                table: "ParametragesExamen");
        }
    }
}
