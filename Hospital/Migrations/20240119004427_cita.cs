using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class cita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Cita",
                newName: "Hora");

            migrationBuilder.AddColumn<DateTime>(
                name: "Día",
                table: "Cita",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Día",
                table: "Cita");

            migrationBuilder.RenameColumn(
                name: "Hora",
                table: "Cita",
                newName: "Horario");
        }
    }
}
