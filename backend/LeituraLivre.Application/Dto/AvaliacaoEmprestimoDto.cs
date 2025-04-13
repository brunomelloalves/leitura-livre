using LeituraLivre.Domain.Entities;

namespace LeituraLivre.Application.DTOs;

public class AvaliacaoEmprestimoDto
{
    public int Id { get; set; }
    public int EmprestimoId { get; set; }
    public EmprestimoDto Emprestimo { get; set; }

    public int Classificacao { get; set; }
    public string? Comentario { get; set; }
}
