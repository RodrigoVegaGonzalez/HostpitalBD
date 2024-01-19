using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Medicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicina_Receta_Medicina_ID_Receta_Medicina",
                table: "Medicina");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Medica_Doctor_DoctorID_Doctor",
                table: "Receta_Medica");

            migrationBuilder.DropTable(
                name: "Receta_Medicina");

            migrationBuilder.DropIndex(
                name: "IX_Receta_Medica_DoctorID_Doctor",
                table: "Receta_Medica");

            migrationBuilder.DropIndex(
                name: "IX_Medicina_ID_Receta_Medicina",
                table: "Medicina");

            migrationBuilder.DropColumn(
                name: "DoctorID_Doctor",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "ID_Receta_Medicina",
                table: "Medicina");

            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "Receta_Medica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duracion",
                table: "Receta_Medica",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Receta_Medica",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ID_Medicina",
                table: "Receta_Medica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tratamiento",
                table: "Receta_Medica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medica_ID_Doctor",
                table: "Receta_Medica",
                column: "ID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medica_ID_Medicina",
                table: "Receta_Medica",
                column: "ID_Medicina",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Medica_Doctor_ID_Doctor",
                table: "Receta_Medica",
                column: "ID_Doctor",
                principalTable: "Doctor",
                principalColumn: "ID_Doctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Medica_Medicina_ID_Medicina",
                table: "Receta_Medica",
                column: "ID_Medicina",
                principalTable: "Medicina",
                principalColumn: "ID_Medicina",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Medica_Doctor_ID_Doctor",
                table: "Receta_Medica");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Medica_Medicina_ID_Medicina",
                table: "Receta_Medica");

            migrationBuilder.DropIndex(
                name: "IX_Receta_Medica_ID_Doctor",
                table: "Receta_Medica");

            migrationBuilder.DropIndex(
                name: "IX_Receta_Medica_ID_Medicina",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "ID_Medicina",
                table: "Receta_Medica");

            migrationBuilder.DropColumn(
                name: "Tratamiento",
                table: "Receta_Medica");

            migrationBuilder.AddColumn<int>(
                name: "DoctorID_Doctor",
                table: "Receta_Medica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_Receta_Medicina",
                table: "Medicina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Receta_Medicina",
                columns: table => new
                {
                    ID_Receta_Medicina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Receta_Medica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta_Medicina", x => x.ID_Receta_Medicina);
                    table.ForeignKey(
                        name: "FK_Receta_Medicina_Receta_Medica_ID_Receta_Medica",
                        column: x => x.ID_Receta_Medica,
                        principalTable: "Receta_Medica",
                        principalColumn: "ID_Receta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medica_DoctorID_Doctor",
                table: "Receta_Medica",
                column: "DoctorID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Medicina_ID_Receta_Medicina",
                table: "Medicina",
                column: "ID_Receta_Medicina");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medicina_ID_Receta_Medica",
                table: "Receta_Medicina",
                column: "ID_Receta_Medica");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicina_Receta_Medicina_ID_Receta_Medicina",
                table: "Medicina",
                column: "ID_Receta_Medicina",
                principalTable: "Receta_Medicina",
                principalColumn: "ID_Receta_Medicina",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Medica_Doctor_DoctorID_Doctor",
                table: "Receta_Medica",
                column: "DoctorID_Doctor",
                principalTable: "Doctor",
                principalColumn: "ID_Doctor");
        }
    }
}
