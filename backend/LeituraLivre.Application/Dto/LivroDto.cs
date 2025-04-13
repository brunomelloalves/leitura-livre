using Microsoft.AspNetCore.Http;

namespace LeituraLivre.Application.DTOs;

public class LivroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Disponivel { get; set; }
    public IFormFile? Capa { get; set; }
}
