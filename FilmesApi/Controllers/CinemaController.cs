using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CinemaController: ControllerBase
{
    private FilmesContext _context;

    public CinemaController(FilmesContext context)
    {
        _context = context;

    }

    [HttpPost]
    public IActionResult CriaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = new Cinema() {nome = cinemaDto.nome, EnderecoId = cinemaDto.EnderecoId};
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

       return CreatedAtAction(nameof(RecuperaCinemasPorId), new {id = cinema.id}, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RetornaCinema()
    {
        var cinemas = _context.Cinemas
      .Include(c => c.Endereco)
      .Include(c => c.Sessoes);

        List<ReadCinemaDto> cinemasDto = new List<ReadCinemaDto>();

        foreach (var cinema in cinemas)
        {
            ReadCinemaDto cinemaDto = new ReadCinemaDto
            {
                
                nome = cinema.nome,
                EnderecoId = cinema.EnderecoId,
                ReadEnderecoDto = new ReadeEnderecoDto
                {
                    
                    logradouro = cinema.Endereco.logradouro,
                    numero = cinema.Endereco.numero
                },

             
            };
            cinemaDto.ReadSessaoDto = cinema.Sessoes.Select(sessao => new ReadSessaoDto
            {
                Id = sessao.Id,

                FilmeId = sessao.FilmeId,
                CinemaId = (int)sessao.CinemaId

            }).ToList();

            cinemasDto.Add(cinemaDto);
        }

        return cinemasDto;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemasPorId(int id)
    {
        Cinema cinema = _context.Cinemas.Include(c => c.Endereco).FirstOrDefault(c => c.id == id);

        if (cinema != null)
        {
            ReadCinemaDto cinemaDto = new ReadCinemaDto
            {
                
                nome = cinema.nome,
                EnderecoId = cinema.EnderecoId,
                ReadEnderecoDto = new ReadeEnderecoDto()
                {
                   
                    logradouro = cinema.Endereco.logradouro,
                    numero = cinema.Endereco.numero
                }
            };

            return Ok(cinemaDto);
        }

        return NotFound();
    }
    [HttpPut("{id}")]

    public IActionResult AtualizaCinema(int id,[FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(Cinema => Cinema.id == id);
        if(cinema == null)
        {
            return NotFound();
        }
        else
        {


            cinema.nome = cinemaDto.nome;
            
            _context.SaveChanges();
            return NoContent();

        }
    }

    [HttpDelete("{id}")]

    public IActionResult DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinemas => cinemas.id == id);
        if (id == null)
        {
            return NotFound();
        }
        else
        {
            
            _context.Remove(cinema);
            _context.SaveChanges();
            
        }
        return NoContent();
        
    }

}
