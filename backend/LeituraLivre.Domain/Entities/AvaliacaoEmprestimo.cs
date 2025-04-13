namespace LeituraLivre.Domain.Entities;

public class AvaliacaoEmprestimo
{
    public int Id { get; set; }
    public int EmprestimoId { get; set; }
    public Emprestimo Emprestimo { get; set; }

    public int Classificacao { get; set; }
    public string? Comentario { get; set; }
}

