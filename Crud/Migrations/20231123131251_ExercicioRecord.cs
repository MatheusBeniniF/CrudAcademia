using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Migrations
{
    /// <inheritdoc />
    public partial class ExercicioRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioRecord_Fichas_FichaId",
                table: "ExercicioRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercicioRecord",
                table: "ExercicioRecord");

            migrationBuilder.RenameTable(
                name: "ExercicioRecord",
                newName: "ExercicioRecords");

            migrationBuilder.RenameIndex(
                name: "IX_ExercicioRecord_FichaId",
                table: "ExercicioRecords",
                newName: "IX_ExercicioRecords_FichaId");

            migrationBuilder.AlterColumn<string>(
                name: "FichaId",
                table: "ExercicioRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercicioRecords",
                table: "ExercicioRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioRecords_Fichas_FichaId",
                table: "ExercicioRecords",
                column: "FichaId",
                principalTable: "Fichas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioRecords_Fichas_FichaId",
                table: "ExercicioRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercicioRecords",
                table: "ExercicioRecords");

            migrationBuilder.RenameTable(
                name: "ExercicioRecords",
                newName: "ExercicioRecord");

            migrationBuilder.RenameIndex(
                name: "IX_ExercicioRecords_FichaId",
                table: "ExercicioRecord",
                newName: "IX_ExercicioRecord_FichaId");

            migrationBuilder.AlterColumn<string>(
                name: "FichaId",
                table: "ExercicioRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercicioRecord",
                table: "ExercicioRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioRecord_Fichas_FichaId",
                table: "ExercicioRecord",
                column: "FichaId",
                principalTable: "Fichas",
                principalColumn: "Id");
        }
    }
}
