using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Mensada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Doctor_Doctor_DoctorID_Doctor",
                table: "Horario_Doctor");

            migrationBuilder.RenameColumn(
                name: "DoctorID_Doctor",
                table: "Horario_Doctor",
                newName: "ID_Doctor");

            migrationBuilder.RenameIndex(
                name: "IX_Horario_Doctor_DoctorID_Doctor",
                table: "Horario_Doctor",
                newName: "IX_Horario_Doctor_ID_Doctor");

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "Horario_Doctor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Doctor_Doctor_ID_Doctor",
                table: "Horario_Doctor",
                column: "ID_Doctor",
                principalTable: "Doctor",
                principalColumn: "ID_Doctor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Doctor_Doctor_ID_Doctor",
                table: "Horario_Doctor");

            migrationBuilder.RenameColumn(
                name: "ID_Doctor",
                table: "Horario_Doctor",
                newName: "DoctorID_Doctor");

            migrationBuilder.RenameIndex(
                name: "IX_Horario_Doctor_ID_Doctor",
                table: "Horario_Doctor",
                newName: "IX_Horario_Doctor_DoctorID_Doctor");

            migrationBuilder.AlterColumn<int>(
                name: "DiaSemana",
                table: "Horario_Doctor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Doctor_Doctor_DoctorID_Doctor",
                table: "Horario_Doctor",
                column: "DoctorID_Doctor",
                principalTable: "Doctor",
                principalColumn: "ID_Doctor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
