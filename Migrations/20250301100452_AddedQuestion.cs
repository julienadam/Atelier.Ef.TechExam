using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    EmailValidation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
