using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Receta_Medica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.AddColumn<int>(
                name: "ID_Cita",
                table: "Receta_Medica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medica_ID_Cita",
                table: "Receta_Medica",
                column: "ID_Cita",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Medica_Cita_ID_Cita",
                table: "Receta_Medica",
                column: "ID_Cita",
                principalTable: "Cita",
                principalColumn: "ID_Cita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Medica_Cita_ID_Cita",
                table: "Receta_Medica");

            migrationBuilder.DropIndex(
                name: "IX_Receta_Medica_ID_Cita",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "ID_Cita",
                table: "Receta_Medica");

            migrationBuilder.AddColumn<int>(
                name: "ID_Receta_Medica",
                table: "Cita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita",
                column: "ID_Receta_Medica",
                unique: true,
                filter: "[ID_Receta_Medica] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                table: "Cita",
                column: "ID_Receta_Medica",
                principalTable: "Receta_Medica",
                principalColumn: "ID_Receta");
        }
    }
}
