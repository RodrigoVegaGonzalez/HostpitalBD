using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID_Doctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consultorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID_Doctor);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    ID_Paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.ID_Paciente);
                    table.ForeignKey(
                        name: "FK_Paciente_AspNetUsers_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    ID_Recepcionista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionista", x => x.ID_Recepcionista);
                    table.ForeignKey(
                        name: "FK_Recepcionista_AspNetUsers_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario_Doctor",
                columns: table => new
                {
                    ID_Horario_Doctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Dia_Hora_Inicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Doctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario_Doctor", x => x.ID_Horario_Doctor);
                    table.ForeignKey(
                        name: "FK_Horario_Doctor_Doctor_ID_Doctor",
                        column: x => x.ID_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "ID_Doctor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receta_Medica",
                columns: table => new
                {
                    ID_Receta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especificaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Doctor = table.Column<int>(type: "int", nullable: false),
                    DoctorID_Doctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta_Medica", x => x.ID_Receta);
                    table.ForeignKey(
                        name: "FK_Receta_Medica_Doctor_DoctorID_Doctor",
                        column: x => x.DoctorID_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "ID_Doctor");
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    ID_Cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consultorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Doctor = table.Column<int>(type: "int", nullable: false),
                    ID_Receta_Medica = table.Column<int>(type: "int", nullable: false),
                    ID_Paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.ID_Cita);
                    table.ForeignKey(
                        name: "FK_Cita_Doctor_ID_Doctor",
                        column: x => x.ID_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "ID_Doctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_ID_Paciente",
                        column: x => x.ID_Paciente,
                        principalTable: "Paciente",
                        principalColumn: "ID_Paciente");
                    table.ForeignKey(
                        name: "FK_Cita_Receta_Medica_ID_Receta_Medica",
                        column: x => x.ID_Receta_Medica,
                        principalTable: "Receta_Medica",
                        principalColumn: "ID_Receta",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    ID_Factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio_Consulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Otro_Servicios = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ID_Cita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.ID_Factura);
                    table.ForeignKey(
                        name: "FK_Factura_Cita_ID_Cita",
                        column: x => x.ID_Cita,
                        principalTable: "Cita",
                        principalColumn: "ID_Cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicina",
                columns: table => new
                {
                    ID_Medicina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    En_Existencia = table.Column<bool>(type: "bit", nullable: false),
                    ID_Receta_Medicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicina", x => x.ID_Medicina);
                    table.ForeignKey(
                        name: "FK_Medicina_Receta_Medicina_ID_Receta_Medicina",
                        column: x => x.ID_Receta_Medicina,
                        principalTable: "Receta_Medicina",
                        principalColumn: "ID_Receta_Medicina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_Doctor",
                table: "Cita",
                column: "ID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_Paciente",
                table: "Cita",
                column: "ID_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_Receta_Medica",
                table: "Cita",
                column: "ID_Receta_Medica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ID_Usuario",
                table: "Doctor",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ID_Cita",
                table: "Factura",
                column: "ID_Cita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Horario_Doctor_ID_Doctor",
                table: "Horario_Doctor",
                column: "ID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Medicina_ID_Receta_Medicina",
                table: "Medicina",
                column: "ID_Receta_Medicina");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_ID_Usuario",
                table: "Paciente",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcionista_ID_Usuario",
                table: "Recepcionista",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medica_DoctorID_Doctor",
                table: "Receta_Medica",
                column: "DoctorID_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medicina_ID_Receta_Medica",
                table: "Receta_Medicina",
                column: "ID_Receta_Medica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Horario_Doctor");

            migrationBuilder.DropTable(
                name: "Medicina");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Receta_Medicina");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Receta_Medica");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
