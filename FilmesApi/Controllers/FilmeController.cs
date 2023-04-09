using FilmesApi.Data;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]  
public class FilmeController : ControllerBase
{
    private FilmesContext _context;

    public FilmeController(FilmesContext context)
    {
        _context = context;
    }

    [HttpPost]

    public  IActionResult adicionarFilmes([FromBody]Filme filme)
    {
        _context.Filme.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(retornaFilmesId), new { id = filme.id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> retornaFilmes()
    {
        return _context.Filme;
    }

    [HttpGet("{id}")]
    public IActionResult retornaFilmesId(int id)
    {
        var filme = _context.Filme.FirstOrDefault(filmes => filmes.id == id);
        if(filme == null)
        {
            return NotFound();
        }
        return Ok(filme);

    }
}
