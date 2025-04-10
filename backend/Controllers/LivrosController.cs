using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = new List<Livro>
            {
                new Livro { Id = 1, Titulo = "Dom Casmurro", Autor = "Machado de Assis", Ano = 1899 },
                new Livro { Id = 2, Titulo = "1984", Autor = "George Orwell", Ano = 1949 },
                new Livro { Id = 3, Titulo = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", Ano = 1943 }
            };

            return Ok(livros);
        }
    }
}
