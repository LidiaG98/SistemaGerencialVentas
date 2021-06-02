using Microsoft.EntityFrameworkCore.Migrations;

namespace SGI_Philips.Data.Migrations
{
    public partial class ModelosFercito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TotalRotacion",
                columns: table => new
                {
                    totalRotacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invCosto = table.Column<double>(nullable: false),
                    invVenta = table.Column<double>(nullable: false),
                    pedidoCompra = table.Column<double>(nullable: false),
                    backOrderTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalRotacion", x => x.totalRotacionID);
                });

            migrationBuilder.CreateTable(
                name: "Rotacion",
                columns: table => new
                {
                    rotacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(nullable: true),
                    mesesInv = table.Column<float>(nullable: false),
                    totalrotacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotacion", x => x.rotacionID);
                    table.ForeignKey(
                        name: "FK_Rotacion_TotalRotacion_totalrotacionID",
                        column: x => x.totalrotacionID,
                        principalTable: "TotalRotacion",
                        principalColumn: "totalRotacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoProducto = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    stock = table.Column<int>(nullable: false),
                    costoP = table.Column<float>(nullable: false),
                    backOrder = table.Column<int>(nullable: false),
                    rotacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoID);
                    table.ForeignKey(
                        name: "FK_Producto_Rotacion_rotacionID",
                        column: x => x.rotacionID,
                        principalTable: "Rotacion",
                        principalColumn: "rotacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consolidado",
                columns: table => new
                {
                    consolidadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anioConsolidado = table.Column<string>(nullable: true),
                    ventasConsolidado = table.Column<int>(nullable: false),
                    productoID = table.Column<int>(nullable: false),
                    mesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolidado", x => x.consolidadoID);
                    table.ForeignKey(
                        name: "FK_Consolidado_Mes_mesID",
                        column: x => x.mesID,
                        principalTable: "Mes",
                        principalColumn: "mesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consolidado_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPhilips",
                columns: table => new
                {
                    productoPhilipsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<double>(nullable: false),
                    codigoPhillips = table.Column<string>(nullable: true),
                    descripcionPhillips = table.Column<string>(nullable: true),
                    categoriaPhilipsID = table.Column<int>(nullable: false),
                    productoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPhilips", x => x.productoPhilipsID);
                    table.ForeignKey(
                        name: "FK_ProductoPhilips_CategoriaPhilips_categoriaPhilipsID",
                        column: x => x.categoriaPhilipsID,
                        principalTable: "CategoriaPhilips",
                        principalColumn: "categoriaPhilipsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoPhilips_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyeccion",
                columns: table => new
                {
                    proyeccionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anioProyeccion = table.Column<string>(nullable: true),
                    ventasProyeccion = table.Column<int>(nullable: false),
                    productoID = table.Column<int>(nullable: false),
                    mesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyeccion", x => x.proyeccionID);
                    table.ForeignKey(
                        name: "FK_Proyeccion_Mes_mesID",
                        column: x => x.mesID,
                        principalTable: "Mes",
                        principalColumn: "mesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyeccion_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consolidado_mesID",
                table: "Consolidado",
                column: "mesID");

            migrationBuilder.CreateIndex(
                name: "IX_Consolidado_productoID",
                table: "Consolidado",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_rotacionID",
                table: "Producto",
                column: "rotacionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPhilips_categoriaPhilipsID",
                table: "ProductoPhilips",
                column: "categoriaPhilipsID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPhilips_productoID",
                table: "ProductoPhilips",
                column: "productoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyeccion_mesID",
                table: "Proyeccion",
                column: "mesID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyeccion_productoID",
                table: "Proyeccion",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Rotacion_totalrotacionID",
                table: "Rotacion",
                column: "totalrotacionID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consolidado");

            migrationBuilder.DropTable(
                name: "ProductoPhilips");

            migrationBuilder.DropTable(
                name: "Proyeccion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Rotacion");

            migrationBuilder.DropTable(
                name: "TotalRotacion");
        }
    }
}
