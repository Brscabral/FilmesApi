using FilmesApi.Data;
using FilmesApi.Data.Dto;
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

    public IActionResult adicionarFilmes([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = new Filme()
        {
            titulo = filmeDto.titulo,
            genero = filmeDto.genero,
            duracao = filmeDto.duracao

        };

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(retornaFilmesId), new { id = filme.id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> retornaFilmes()
    {
        return _context.Filmes;
    }

    [HttpGet("{id}")]
    public IActionResult retornaFilmesId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filmes => filmes.id == id);
        if (filme == null)
        {
            return NotFound();
        }
        ReadFilmeDto RfilmeDto = new ReadFilmeDto();


        filme.titulo = RfilmeDto.titulo;
        filme.genero = RfilmeDto.genero;
        filme.duracao = RfilmeDto.duracao;

        var filmeDto = filme;


        return Ok(filmeDto);

    }

    [HttpPut("{id}")]

    public IActionResult atualizaFilmeDto(int id, [FromBody] UpdateFilmeDto filmedto) {
        var filme = _context.Filmes.FirstOrDefault(FilmesApi => FilmesApi.id == id);
        if (filme == null)
        {
            return NotFound();
        }
        else
        {
            filme.titulo = filmedto.titulo;
            filme.genero = filmedto.genero;
            filme.duracao = filmedto.duracao;

            _context.SaveChanges();
            return NoContent();

        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeletaFilmeDto (int id, [FromBody] DeleteFilmeDto filmedto)
    {
        var filme = _context.Filmes.FirstOrDefault(FilmesApi => FilmesApi.id == id);
        if(filme == null)
        {
            return NotFound();
        }
        else
        {
            filme.titulo = filmedto.titulo;
            filme.genero = filmedto.genero;
            filme.duracao = filmedto.duracao;

            _context.Remove(filme);
            _context.SaveChanges();
        }

        return NoContent();
    }
}
