using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeituraLivre.Application.Dto;

public class LivroListagemDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Disponivel { get; set; }

    public string? CapaBase64 { get; set; }
}
