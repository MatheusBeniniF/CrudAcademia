using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    /// <inheritdoc />
    public partial class NovaFicha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastros");

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioRecord",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Exercicio = table.Column<string>(type: "TEXT", nullable: false),
                    Intervalo = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdSeries = table.Column<int>(type: "INTEGER", nullable: false),
                    Repeticoes = table.Column<int>(type: "INTEGER", nullable: false),
                    FichaId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercicioRecord_Fichas_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Fichas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioRecord_FichaId",
                table: "ExercicioRecord",
                column: "FichaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioRecord");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.Id);
                });
        }
    }
}
