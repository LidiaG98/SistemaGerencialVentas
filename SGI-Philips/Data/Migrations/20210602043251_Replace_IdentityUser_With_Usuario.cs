using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGI_Philips.Data.Migrations
{
    public partial class Replace_IdentityUser_With_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apellidos",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dui",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaNacimiento",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "idPuesto",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombres",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nup",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "puestoID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_puestoID",
                table: "AspNetUsers",
                column: "puestoID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Puesto_puestoID",
                table: "AspNetUsers",
                column: "puestoID",
                principalTable: "Puesto",
                principalColumn: "puestoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Puesto_puestoID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_puestoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "dui",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "idPuesto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nup",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "puestoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "AspNetUsers");
        }
    }
}
