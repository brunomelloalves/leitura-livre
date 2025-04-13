using LeituraLivre.Domain.Entities;

namespace LeituraLivre.Application.DTOs;

public class EmprestimoDto
{
    public int Id { get; set; }

    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucaoPrevista { get; set; }
    public DateTime? DataDevolucaoRealizada { get; set; }

    public int LivroId { get; set; }
    public LivroDto Livro { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public ICollection<AvaliacaoEmprestimoDto>? Avaliacoes { get; set; }
}
