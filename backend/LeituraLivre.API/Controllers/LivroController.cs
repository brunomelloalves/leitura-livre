using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeituraLivre.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroDto>>> Get()
    {
        var livros = await _livroService.ObterTodosAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LivroDto>> Get(int id)
    {
        var livro = await _livroService.ObterPorIdAsync(id);
        if (livro == null) return NotFound();
        return Ok(livro);
    }

    [HttpPost]
    public async Task<ActionResult> Post(LivroDto dto)
    {
        var novoLivro = await _livroService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novoLivro.Id }, novoLivro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, LivroDto dto)
    {
        var atualizado = await _livroService.AtualizarAsync(id, dto);
        if (!atualizado) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _livroService.RemoverAsync(id);
        if (!removido) return NotFound();
        return NoContent();
    }
}