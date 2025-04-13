using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AvaliacaoLivroMap : IEntityTypeConfiguration<AvaliacaoLivro>
{
    public void Configure(EntityTypeBuilder<AvaliacaoLivro> builder)
    {
        builder.ToTable("AvaliacoesLivro");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Classificacao).IsRequired();
        builder.Property(a => a.Comentario).HasMaxLength(1000);

        builder.HasOne(a => a.Livro)
            .WithMany(l => l.Avaliacoes)
            .HasForeignKey(a => a.LivroId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
