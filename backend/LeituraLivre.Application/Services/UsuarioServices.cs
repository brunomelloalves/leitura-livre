using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using LeituraLivre.Domain.Entities;
using LeituraLivre.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace LeituraLivre.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDto>> ObterTodosAsync()
        {
            return await _context.Usuario
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Telefone = u.Telefone,
                    Email = u.Email,
                    NrImovel = u.NrImovel
                })
                .ToListAsync();
        }

        public async Task<UsuarioDto?> ObterPorIdAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                NrImovel = usuario.NrImovel
            };
        }

        public async Task<UsuarioDto> AdicionarAsync(UsuarioDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                NrImovel = dto.NrImovel,
                Senha = dto.Senha
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            dto.Id = usuario.Id;
            return dto;
        }

        public async Task<bool> AtualizarAsync(int id, UsuarioDto dto)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return false;

            usuario.Nome = dto.Nome;
            usuario.Telefone = dto.Telefone;
            usuario.Email = dto.Email;
            usuario.NrImovel = dto.NrImovel;
            if (!string.IsNullOrWhiteSpace(dto.Senha))
                usuario.Senha = dto.Senha;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
