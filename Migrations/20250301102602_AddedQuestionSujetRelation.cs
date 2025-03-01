using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuestionSujetRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionSujet",
                columns: table => new
                {
                    QuestionsQuestionId = table.Column<int>(type: "int", nullable: false),
                    SujetsSujetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSujet", x => new { x.QuestionsQuestionId, x.SujetsSujetId });
                    table.ForeignKey(
                        name: "FK_QuestionSujet_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSujet_Sujets_SujetsSujetId",
                        column: x => x.SujetsSujetId,
                        principalTable: "Sujets",
                        principalColumn: "SujetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSujet_SujetsSujetId",
                table: "QuestionSujet",
                column: "SujetsSujetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionSujet");
        }
    }
}
