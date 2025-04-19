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
                    NrImovel = u.NrImovel,
                    Aprovado = u.Aprovado
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
                NrImovel = usuario.NrImovel,
                Aprovado = usuario.Aprovado
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
                NomeUsuario = dto.NomeUsuario,
                Senha = dto.Senha,
                Aprovado = dto.Aprovado,
                Admin = dto.Admin
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
            usuario.Aprovado = dto.Aprovado;
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

        public async Task<UsuarioDto> Login(string nomeUsuario, string senha)
        {
            var usuario = await _context.Usuario.FirstAsync(u => u.NomeUsuario == nomeUsuario);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                NrImovel = usuario.NrImovel,
                Aprovado = usuario.Aprovado,
                Senha = usuario.Senha,
                Admin = usuario.Admin,
                NomeUsuario = usuario.NomeUsuario
            };
        }
    }
}
