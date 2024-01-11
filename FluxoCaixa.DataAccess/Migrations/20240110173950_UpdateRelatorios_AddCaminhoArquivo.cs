using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelatorios_AddCaminhoArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "caminho_arquivo",
                table: "relatorios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caminho_arquivo",
                table: "relatorios");
        }
    }
}
