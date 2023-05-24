using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IEnumerable<ReadFilmeDto> RecuperaFilme()
    {
        var filmes = _context.Filmes
        .Include(f => f.Sessoes);
     

        List<ReadFilmeDto> filmesDto = new List<ReadFilmeDto>();

        foreach (var filme in filmes)
        {
            ReadFilmeDto filmeDto = new ReadFilmeDto
            {

                titulo = filme.titulo,
                genero = filme.genero,
                duracao = filme.duracao

            };
            filmeDto.Sessoes = filme.Sessoes.Select(sessao => new ReadSessaoDto
            {
                FilmeId = sessao.FilmeId,
                CinemaId = sessao.CinemaId ?? 0

                // Mapeie outras propriedades relevantes da sessão
            }).ToList();

            filmesDto.Add(filmeDto);
        }

        return filmesDto;
    }

    [HttpGet("{id}")]
    public IActionResult retornaFilmesId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filmes => filmes.id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);

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
