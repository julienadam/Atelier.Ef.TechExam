using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuestionNiveauAndIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "Questions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sujets_Titre",
                table: "Sujets",
                column: "Titre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Niveau",
                table: "Questions",
                column: "Niveau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sujets_Titre",
                table: "Sujets");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Niveau",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "Questions");
        }
    }
}
