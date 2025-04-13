using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("Emprestimos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.DataEmprestimo)
            .IsRequired();

        builder.Property(e => e.DataDevolucaoPrevista);
        builder.Property(e => e.DataDevolucaoRealizada);

        builder.HasOne(e => e.Livro)
            .WithMany()
            .HasForeignKey(e => e.LivroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Usuario)
            .WithMany(u => u.Emprestimos)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Avaliacoes)
            .WithOne(a => a.Emprestimo)
            .HasForeignKey(a => a.EmprestimoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
