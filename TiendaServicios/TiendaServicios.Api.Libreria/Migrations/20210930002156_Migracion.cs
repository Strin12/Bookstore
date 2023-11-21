using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Libreria.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Librerias",
                columns: table => new
                {
                    LibreriasId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TituloLibro = table.Column<string>(nullable: true),
                    FechaPublicacion = table.Column<DateTime>(nullable: true),
                    AutorLibro = table.Column<string>(nullable: true),
                    LibreriaGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librerias", x => x.LibreriasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Librerias");
        }
    }
}
