using LeituraLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome).HasMaxLength(150);
        builder.Property(u => u.Telefone).HasMaxLength(20);
        builder.Property(u => u.Email).HasMaxLength(150).IsRequired();
        builder.Property(u => u.NrImovel).IsRequired();
        builder.Property(u => u.Senha).HasMaxLength(100).IsRequired();

        builder.HasMany(u => u.Emprestimos)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
