using LeituraLivre.Domain.Entities;

namespace LeituraLivre.Application.DTOs;

public class ArquivoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string TipoMime { get; set; }
    public byte[] Conteudo { get; set; }

    public LivroDto? Livro { get; set; }
}
