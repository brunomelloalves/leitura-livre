using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeituraLivre.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
    {
        var livros = await _usuarioService.ObterTodosAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> Get(int id)
    {
        var livro = await _usuarioService.ObterPorIdAsync(id);
        if (livro == null) return NotFound();
        return Ok(livro);
    }

    [HttpPost]
    public async Task<ActionResult> Post(UsuarioDto dto)
    {
        var novo = await _usuarioService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UsuarioDto dto)
    {
        var atualizado = await _usuarioService.AtualizarAsync(id, dto);
        if (!atualizado) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _usuarioService.RemoverAsync(id);
        if (!removido) return NotFound();
        return NoContent();
    }
}