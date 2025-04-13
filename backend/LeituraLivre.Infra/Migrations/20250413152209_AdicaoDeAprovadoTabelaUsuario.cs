using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeituraLivre.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDeAprovadoTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Usuarios");
        }
    }
}
