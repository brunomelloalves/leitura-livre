namespace LeituraLivre.Domain.Entities;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public string Categoria { get; set; }
    public bool Disponivel { get; set; }
}
