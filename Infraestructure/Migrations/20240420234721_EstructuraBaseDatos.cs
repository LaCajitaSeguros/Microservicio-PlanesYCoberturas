using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class EstructuraBaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobertura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobertura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criterio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotizacionMinima = table.Column<int>(type: "int", nullable: false),
                    CotizacionMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanCobertura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCobertura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanCobertura_Cobertura_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Cobertura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanCobertura_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanCriterio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    CriterioId = table.Column<int>(type: "int", nullable: false),
                    PorcentajeAumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCriterio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanCriterio_Criterio_CriterioId",
                        column: x => x.CriterioId,
                        principalTable: "Criterio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanCriterio_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cobertura",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Responsabilidad Civil" },
                    { 2, "Protección al conductor" },
                    { 3, "Asistencia al viajero" },
                    { 4, "Monto asegurado actualizado" },
                    { 5, "Robo Total y Parcial" },
                    { 6, "Destrucción Total" },
                    { 7, "Incendio Total y Parcial" },
                    { 8, "Cristales y Cerraduras sin límite" },
                    { 9, "Cubiertas y llantas (por robo)" },
                    { 10, "Granizo" },
                    { 11, "Servicio de auxilio y remolque" },
                    { 12, "Reposición 0Km" }
                });

            migrationBuilder.InsertData(
                table: "Criterio",
                columns: new[] { "Id", "CotizacionMaxima", "CotizacionMinima" },
                values: new object[,]
                {
                    { 1, 20000, 0 },
                    { 2, 30000, 20001 },
                    { 3, 40000, 30001 },
                    { 4, 50000, 40001 },
                    { 5, 60000, 50001 }
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Plan Basico" },
                    { 2, "Plan Intermedio" },
                    { 3, "Plan Full" }
                });

            migrationBuilder.InsertData(
                table: "PlanCobertura",
                columns: new[] { "Id", "CoberturaId", "PlanId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 2 },
                    { 6, 2, 2 },
                    { 7, 3, 2 },
                    { 8, 4, 2 },
                    { 9, 5, 2 },
                    { 10, 6, 2 },
                    { 11, 7, 2 },
                    { 12, 8, 2 },
                    { 13, 1, 3 },
                    { 14, 2, 3 },
                    { 15, 3, 3 },
                    { 16, 4, 3 },
                    { 17, 5, 3 },
                    { 18, 6, 3 },
                    { 19, 7, 3 },
                    { 20, 8, 3 },
                    { 21, 9, 3 },
                    { 22, 10, 3 },
                    { 23, 11, 3 },
                    { 24, 12, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlanCriterio",
                columns: new[] { "Id", "CriterioId", "PlanId", "PorcentajeAumento" },
                values: new object[,]
                {
                    { 1, 1, 1, 5 },
                    { 2, 2, 1, 7 },
                    { 3, 3, 1, 10 },
                    { 4, 4, 1, 12 },
                    { 5, 5, 1, 15 },
                    { 6, 1, 2, 17 },
                    { 7, 2, 2, 20 },
                    { 8, 3, 2, 23 },
                    { 9, 4, 2, 26 },
                    { 10, 5, 2, 29 },
                    { 11, 1, 3, 31 },
                    { 12, 2, 3, 34 },
                    { 13, 3, 3, 37 },
                    { 14, 4, 3, 40 },
                    { 15, 5, 3, 43 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanCobertura_CoberturaId",
                table: "PlanCobertura",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCobertura_PlanId",
                table: "PlanCobertura",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCriterio_CriterioId",
                table: "PlanCriterio",
                column: "CriterioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCriterio_PlanId",
                table: "PlanCriterio",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanCobertura");

            migrationBuilder.DropTable(
                name: "PlanCriterio");

            migrationBuilder.DropTable(
                name: "Cobertura");

            migrationBuilder.DropTable(
                name: "Criterio");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
