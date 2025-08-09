using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinLensAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UltimoDividendo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapitalizacaoMercado = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MercadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_MercadoId",
                table: "Comentarios",
                column: "MercadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Mercados");
        }
    }
}
