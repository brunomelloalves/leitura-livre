using System.Collections.Generic;

namespace LeituraLivre.Domain.Entities;

public class Usuario
{
	public int Id { get; set; }
	public string? Nome { get; set; }
	public string? Telefone { get; set; }
	public string? Email { get; set; }
	public int NrImovel { get; set; }
	public string? Senha { get; set; }

	public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
