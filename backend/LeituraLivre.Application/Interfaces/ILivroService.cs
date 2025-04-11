using LeituraLivre.Application.DTOs;

namespace LeituraLivre.Application.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<LivroDto>> ObterTodosAsync();
    Task<LivroDto?> ObterPorIdAsync(int id);
    Task<LivroDto> AdicionarAsync(LivroDto dto);
    Task<bool> AtualizarAsync(int id, LivroDto dto);
    Task<bool> RemoverAsync(int id);
}
