namespace LeituraLivre.Domain.Entities;

public class Arquivo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string TipoMime { get; set; }
    public byte[] Conteudo { get; set; }
    
    public Livro? Livro { get; set; }
}

