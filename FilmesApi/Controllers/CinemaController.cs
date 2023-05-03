using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

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
        Cinema cinema = new Cinema() {nome = cinemaDto.nome };
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

       return CreatedAtAction(nameof(RetornaCinemaId), new {id = cinema.id}, cinema);
    }

    [HttpGet]
    public IEnumerable<Cinema> retornaCinema() { return _context.Cinemas; }

    [HttpGet("{id}")]

    public IActionResult RetornaCinemaId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinemas => cinemas.id == id);
        if (id == null)
        {
            return NotFound();
        }
        return Ok(cinema);
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
