using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ArquivoMap : IEntityTypeConfiguration<Arquivo>
{
    public void Configure(EntityTypeBuilder<Arquivo> builder)
    {
        builder.ToTable("Arquivos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome).IsRequired().HasMaxLength(255);
        builder.Property(a => a.TipoMime).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Conteudo).IsRequired();

        builder.HasOne(a => a.Livro)
            .WithOne(l => l.Capa)
            .HasForeignKey<Livro>(l => l.CapaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
