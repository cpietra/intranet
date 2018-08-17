using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace intranet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id_Proceso = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Proceso = table.Column<string>(nullable: true),
                    Numeral = table.Column<string>(nullable: true),
                    Unidad = table.Column<string>(nullable: true),
                    Fuente = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true),
                    ProcesosId_Proceso = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id_Proceso);
                    table.ForeignKey(
                        name: "FK_Procesos_Procesos_ProcesosId_Proceso",
                        column: x => x.ProcesosId_Proceso,
                        principalTable: "Procesos",
                        principalColumn: "Id_Proceso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id_Registro = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Periodo = table.Column<string>(nullable: true),
                    Numerador = table.Column<float>(nullable: false),
                    Denominador = table.Column<float>(nullable: false),
                    Indicador = table.Column<float>(nullable: false),
                    Meta = table.Column<float>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    Reg_ProcesoId_Proceso = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id_Registro);
                    table.ForeignKey(
                        name: "FK_Registros_Procesos_Reg_ProcesoId_Proceso",
                        column: x => x.Reg_ProcesoId_Proceso,
                        principalTable: "Procesos",
                        principalColumn: "Id_Proceso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_ProcesosId_Proceso",
                table: "Procesos",
                column: "ProcesosId_Proceso");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Reg_ProcesoId_Proceso",
                table: "Registros",
                column: "Reg_ProcesoId_Proceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Procesos");
        }
    }
}
