using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeituraLivre.Infra.Migrations
{
    public partial class InsetAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO public.""Usuarios"" (
                    ""Nome"", 
                    ""Telefone"", 
                    ""Email"", 
                    ""NrImovel"", 
                    ""Senha"", 
                    ""Aprovado"", 
                    ""NomeUsuario"", 
                    ""Admin""
                ) VALUES (
                    'Administrador do Sistema',
                    '00000000000',
                    'admin@leituralivre.local',
                    0,
                    'admin',
                    TRUE,
                    'admin',
                    TRUE
                );
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM public.""Usuarios""
                WHERE ""NomeUsuario"" = 'admin';
            ");
        }

    }
}
