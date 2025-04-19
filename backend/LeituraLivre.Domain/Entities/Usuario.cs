using LeituraLivre.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public int NrImovel { get; set; }

    public string? NomeUsuario { get; set; }
    public string? Senha { get; set; }
    public bool Aprovado { get; set; }
    public bool Admin { get; set; }

    public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
