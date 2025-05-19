using LeituraLivre.Application.DTOs;
using LeituraLivre.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeituraLivre.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimoController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }

    [HttpPost]
    public async Task<ActionResult> Post(EmprestimoDto dto)
    {
        var novoEmprestimo = await _emprestimoService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(Post), new { id = novoEmprestimo.Id }, novoEmprestimo);
    }
}