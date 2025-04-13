using LeituraLivre.Domain.Entities;

namespace LeituraLivre.Application.DTOs;

public class AvaliacaoLivroDto
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public LivroDto Livro { get; set; }

    public int Classificacao { get; set; }
    public string? Comentario { get; set; }
}
