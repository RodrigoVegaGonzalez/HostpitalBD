using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Horario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDoctorVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID_Doctor = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDoctorVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDoctorVM_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDoctorVM_Doctor_DoctorID_Doctor",
                        column: x => x.DoctorID_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "ID_Doctor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDoctorVM_DoctorID_Doctor",
                table: "UsuarioDoctorVM",
                column: "DoctorID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDoctorVM_UsuarioId",
                table: "UsuarioDoctorVM",
                column: "UsuarioId");
        }
    }
}
