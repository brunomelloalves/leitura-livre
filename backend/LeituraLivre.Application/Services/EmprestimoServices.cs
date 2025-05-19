using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using LeituraLivre.Domain.Entities;
using LeituraLivre.Infra.Data;

namespace LeituraLivre.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly AppDbContext _context;

        public EmprestimoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmprestimoDto> AdicionarAsync(EmprestimoDto dto)
        {
            var entidade = new Emprestimo
            {
                DataEmprestimo = dto.DataEmprestimo,
                DataDevolucaoPrevista = dto.DataDevolucaoPrevista,
                DataDevolucaoRealizada = null,
                LivroId = dto.LivroId,
                UsuarioId = dto.UsuarioId
            };

            _context.Emprestimo.Add(entidade);
            await _context.SaveChangesAsync();

            var resultado = new EmprestimoDto
            {
                Id = entidade.Id,
                DataEmprestimo = entidade.DataEmprestimo,
                DataDevolucaoPrevista = entidade.DataDevolucaoPrevista,
                DataDevolucaoRealizada = entidade.DataDevolucaoRealizada,
                LivroId = entidade.LivroId,
                UsuarioId = entidade.UsuarioId
            };

            return resultado;
        }

        public Task<bool> AtualizarAsync(int id, EmprestimoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<EmprestimoDto?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmprestimoDto>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}