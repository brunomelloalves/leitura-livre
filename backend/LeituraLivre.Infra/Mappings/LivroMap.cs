using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeituraLivre.Infra.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Autor).IsRequired().HasMaxLength(80);
            builder.Property(x => x.AnoPublicacao);
            builder.Property(x => x.Categoria).HasMaxLength(50);
            builder.Property(x => x.Disponivel).IsRequired();
        }
    }
}
