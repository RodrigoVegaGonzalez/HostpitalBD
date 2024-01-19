using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Especialidad",
                table: "Especialidad",
                newName: "ID_Especialidad");

            migrationBuilder.RenameColumn(
                name: "Id_Consultorio",
                table: "Consultorio",
                newName: "ID_Consultorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_Especialidad",
                table: "Especialidad",
                newName: "Id_Especialidad");

            migrationBuilder.RenameColumn(
                name: "ID_Consultorio",
                table: "Consultorio",
                newName: "Id_Consultorio");
        }
    }
}
