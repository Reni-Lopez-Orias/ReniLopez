using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Entidades.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "dbo",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    apellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    correo_electronico = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    telefono = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: true),
                    pais_residencia = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    contacto = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "actividades",
                schema: "dbo",
                columns: table => new
                {
                    id_actividades = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    create_date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    id_usuario = table.Column<int>(type: "INT", nullable: false),
                    actividad = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actividades", x => x.id_actividades);
                    table.ForeignKey(
                        name: "FK_actividades_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "dbo",
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actividades_id_usuario",
                schema: "dbo",
                table: "actividades",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actividades",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "dbo");
        }
    }
}
