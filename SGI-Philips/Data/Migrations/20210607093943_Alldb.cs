using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGI_Philips.Data.Migrations
{
    public partial class Alldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialDeActividad",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    historialDeActividadID = table.Column<int>(nullable: false),
                    tipoActividad = table.Column<string>(nullable: true),
                    fechaCreación = table.Column<DateTime>(nullable: false),
                    fechaActualización = table.Column<DateTime>(nullable: false),
                    usuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialDeActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialDeActividad_AspNetUsers_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialDeActividad_usuarioId",
                table: "HistorialDeActividad",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialDeActividad");
        }
    }
}
