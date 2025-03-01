using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstraintsOnPourcentagesAndNiveau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_niveau_is_correct",
                table: "Questions",
                sql: "Niveau IN ('Debutant', 'Intermediaire', 'Avance')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_percentages_are_correct",
                table: "ParametragesExamen",
                sql: "PourcentageDebutant >= 0 AND PourcentageIntermediaire >= 0 AND PourcentageAvance >= 0 AND PourcentageDebutant + PourcentageIntermediaire + PourcentageAvance = 100");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_niveau_is_correct",
                table: "Questions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_percentages_are_correct",
                table: "ParametragesExamen");
        }
    }
}
