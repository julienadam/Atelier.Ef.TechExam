using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class Passage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passages",
                columns: table => new
                {
                    PassageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParametrageExamenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RendezVous = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RaisonAnnulation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passages", x => x.PassageId);
                    table.ForeignKey(
                        name: "FK_Passages_ParametragesExamen_ParametrageExamenId",
                        column: x => x.ParametrageExamenId,
                        principalTable: "ParametragesExamen",
                        principalColumn: "ParametrageExamenId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passages_ParametrageExamenId",
                table: "Passages",
                column: "ParametrageExamenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passages");
        }
    }
}
