using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    /// <inheritdoc />
    public partial class Exercicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anotacoes",
                table: "Fichas");

            migrationBuilder.AddColumn<bool>(
                name: "Sugestao",
                table: "Fichas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Anotacoes",
                table: "ExercicioRecords",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sugestao",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "Anotacoes",
                table: "ExercicioRecords");

            migrationBuilder.AddColumn<string>(
                name: "Anotacoes",
                table: "Fichas",
                type: "TEXT",
                nullable: true);
        }
    }
}
