using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedParametrageExamen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametragesExamen",
                columns: table => new
                {
                    ParametrageExamenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Contient l'identifiant de l'offre d'emploi en provenance du système RH amont. La valeur n'est pas générée par le système et doit être spécifiée côté client."),
                    PourcentageDebutant = table.Column<int>(type: "int", nullable: false),
                    PourcentageIntermediaire = table.Column<int>(type: "int", nullable: false),
                    PourcentageAvance = table.Column<int>(type: "int", nullable: false),
                    DureeMinutes = table.Column<int>(type: "int", nullable: false),
                    QuestionsLibres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametragesExamen", x => x.ParametrageExamenId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametragesExamen");
        }
    }
}
