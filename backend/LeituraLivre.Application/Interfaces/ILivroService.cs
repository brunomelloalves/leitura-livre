using LeituraLivre.Application.Dto;
using LeituraLivre.Application.DTOs;

namespace LeituraLivre.Application.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<LivroListagemDto>> ObterTodosAsync();
    Task<LivroDto?> ObterPorIdAsync(int id);
    Task<LivroDto> AdicionarAsync(LivroDto dto);
    Task<bool> AtualizarAsync(int id, LivroDto dto);
    Task<bool> RemoverAsync(int id);
}
