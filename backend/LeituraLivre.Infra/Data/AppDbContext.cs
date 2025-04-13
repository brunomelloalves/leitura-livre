using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeituraLivre.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<AvaliacaoEmprestimo> AvaliacaoEmprestimo { get; set; }
        public DbSet<AvaliacaoLivro> AvaliacaoLivro { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
