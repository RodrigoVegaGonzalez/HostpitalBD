using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class NullRecetaMedica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.AlterColumn<int>(
                name: "ID_Receta_Medica",
                table: "Cita",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita");

            migrationBuilder.AlterColumn<int>(
                name: "ID_Receta_Medica",
                table: "Cita",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita",
                column: "ID_Receta_Medica",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                table: "Cita",
                column: "ID_Receta_Medica",
                principalTable: "Receta_Medica",
                principalColumn: "ID_Receta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
