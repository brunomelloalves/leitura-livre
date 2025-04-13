namespace LeituraLivre.Domain.Entities;

public class Emprestimo
{
    public int Id { get; set; }

    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucaoPrevista { get; set; }
    public DateTime? DataDevolucaoRealizada { get; set; }

    public int LivroId { get; set; }
    public Livro Livro { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public ICollection<AvaliacaoEmprestimo>? Avaliacoes { get; set; }
}
