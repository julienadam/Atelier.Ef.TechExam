using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    /// <inheritdoc />
    public partial class HeritageQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailValidation",
                table: "Questions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Questions",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "EmailValidation",
                table: "Questions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.");
        }
    }
}
