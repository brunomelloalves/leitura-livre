using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeituraLivre.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Usuarios",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Usuarios");
        }
    }
}
