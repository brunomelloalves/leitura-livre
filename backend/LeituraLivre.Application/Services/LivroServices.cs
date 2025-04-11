using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using LeituraLivre.Domain.Entities;
using LeituraLivre.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace LeituraLivre.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosAsync()
        {
            return await _context.Livros
                .Select(l => new LivroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    AnoPublicacao = l.AnoPublicacao,
                    Categoria = l.Categoria,
                    Disponivel = l.Disponivel
                })
                .ToListAsync();
        }

        public async Task<LivroDto?> ObterPorIdAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return null;

            return new LivroDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                AnoPublicacao = livro.AnoPublicacao,
                Categoria = livro.Categoria,
                Disponivel = livro.Disponivel
            };
        }

        public async Task<LivroDto> AdicionarAsync(LivroDto dto)
        {
            var livro = new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                AnoPublicacao = dto.AnoPublicacao,
                Categoria = dto.Categoria,
                Disponivel = dto.Disponivel
            };

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            dto.Id = livro.Id;
            return dto;
        }

        public async Task<bool> AtualizarAsync(int id, LivroDto dto)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            livro.Titulo = dto.Titulo;
            livro.Autor = dto.Autor;
            livro.AnoPublicacao = dto.AnoPublicacao;
            livro.Categoria = dto.Categoria;
            livro.Disponivel = dto.Disponivel;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}