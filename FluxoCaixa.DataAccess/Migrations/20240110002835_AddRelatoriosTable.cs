using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRelatoriosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "relatorios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caixa = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relatorios", x => x.id);
                    table.ForeignKey(
                        name: "fk_relatorios_caixas_id_caixa",
                        column: x => x.id_caixa,
                        principalTable: "caixas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_relatorios_id_caixa",
                table: "relatorios",
                column: "id_caixa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relatorios");
        }
    }
}
