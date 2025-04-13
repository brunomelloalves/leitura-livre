using LeituraLivre.Application.DTOs;
using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeituraLivre.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> ObterTodosAsync();
    Task<UsuarioDto?> ObterPorIdAsync(int id);
    Task<UsuarioDto> AdicionarAsync(UsuarioDto dto);
    Task<bool> AtualizarAsync(int id, UsuarioDto dto);
    Task<bool> RemoverAsync(int id);
}
