using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AvaliacaoEmprestimoMap : IEntityTypeConfiguration<AvaliacaoEmprestimo>
{
    public void Configure(EntityTypeBuilder<AvaliacaoEmprestimo> builder)
    {
        builder.ToTable("AvaliacoesEmprestimo");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Classificacao).IsRequired();
        builder.Property(a => a.Comentario).HasMaxLength(1000);

        builder.HasOne(a => a.Emprestimo)
            .WithMany(e => e.Avaliacoes)
            .HasForeignKey(a => a.EmprestimoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
