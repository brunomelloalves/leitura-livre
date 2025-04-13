using LeituraLivre.Application.DTOs;

namespace LeituraLivre.Application.Interfaces;

public interface IEmprestimoService
{
    Task<IEnumerable<EmprestimoDto>> ObterTodosAsync();
    Task<EmprestimoDto?> ObterPorIdAsync(int id);
    Task<EmprestimoDto> AdicionarAsync(EmprestimoDto dto);
    Task<bool> AtualizarAsync(int id, EmprestimoDto dto);
    Task<bool> RemoverAsync(int id);
}
