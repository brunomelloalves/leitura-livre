using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeituraLivre.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelaUsuario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Usuarios");
        }
    }
}
