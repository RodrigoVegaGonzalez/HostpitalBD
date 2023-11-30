using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID_Usuario",
                table: "Doctor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ID_Usuario",
                table: "Doctor",
                column: "ID_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_AspNetUsers_ID_Usuario",
                table: "Doctor",
                column: "ID_Usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_AspNetUsers_ID_Usuario",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ID_Usuario",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ID_Usuario",
                table: "Doctor");
        }
    }
}
