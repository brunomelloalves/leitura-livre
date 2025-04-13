namespace LeituraLivre.Domain.Entities;

public class AvaliacaoLivro
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public Livro Livro { get; set; }

    public int Classificacao { get; set; }
    public string? Comentario { get; set; }
}
