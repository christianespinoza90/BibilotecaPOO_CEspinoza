using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibilotecaPOO_CEspinoza.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibroCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutorCedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Autores_AutorCedula",
                        column: x => x.AutorCedula,
                        principalTable: "Autores",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_LibroCodigo",
                        column: x => x.LibroCodigo,
                        principalTable: "Libros",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_AutorCedula",
                table: "Prestamos",
                column: "AutorCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LibroCodigo",
                table: "Prestamos",
                column: "LibroCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
