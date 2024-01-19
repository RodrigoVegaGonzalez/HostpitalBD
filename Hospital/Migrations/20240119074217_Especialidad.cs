using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Especialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Consultorio_id_Consultorio",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Especialidad_Doctor_DoctorID_Doctor",
                table: "Especialidad");

            migrationBuilder.DropIndex(
                name: "IX_Especialidad_DoctorID_Doctor",
                table: "Especialidad");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_id_Consultorio",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorID_Doctor",
                table: "Especialidad");

            migrationBuilder.RenameColumn(
                name: "id_Consultorio",
                table: "Doctor",
                newName: "ID_Consultorio");

            migrationBuilder.AddColumn<int>(
                name: "ID_Especialidad",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ID_Consultorio",
                table: "Doctor",
                column: "ID_Consultorio",
                unique: true,
                filter: "[ID_Consultorio] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ID_Especialidad",
                table: "Doctor",
                column: "ID_Especialidad",
                unique: true,
                filter: "[ID_Especialidad] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Consultorio_ID_Consultorio",
                table: "Doctor",
                column: "ID_Consultorio",
                principalTable: "Consultorio",
                principalColumn: "ID_Consultorio");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Especialidad_ID_Especialidad",
                table: "Doctor",
                column: "ID_Especialidad",
                principalTable: "Especialidad",
                principalColumn: "ID_Especialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Consultorio_ID_Consultorio",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Especialidad_ID_Especialidad",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ID_Consultorio",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ID_Especialidad",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ID_Especialidad",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "ID_Consultorio",
                table: "Doctor",
                newName: "id_Consultorio");

            migrationBuilder.AddColumn<int>(
                name: "DoctorID_Doctor",
                table: "Especialidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidad_DoctorID_Doctor",
                table: "Especialidad",
                column: "DoctorID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_id_Consultorio",
                table: "Doctor",
                column: "id_Consultorio",
                unique: true,
                filter: "[id_Consultorio] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Consultorio_id_Consultorio",
                table: "Doctor",
                column: "id_Consultorio",
                principalTable: "Consultorio",
                principalColumn: "ID_Consultorio");

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidad_Doctor_DoctorID_Doctor",
                table: "Especialidad",
                column: "DoctorID_Doctor",
                principalTable: "Doctor",
                principalColumn: "ID_Doctor");
        }
    }
}
