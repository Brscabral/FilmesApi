using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]

public class SessaoController : ControllerBase
{
    private FilmesContext _context;
    public SessaoController(FilmesContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CriaSessao([FromBody] CreateSessaoDto sessaoDto)
    {
        Sessao sessao = new Sessao() { FilmeId = sessaoDto.FilmeId, CinemaId = sessaoDto.CinemaId};
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
    }
    [HttpGet]
    public IEnumerable<ReadSessaoDto> GetSessoes(ReadSessaoDto rsessao)
    {
        var sessoes = _context.Sessoes
            .Where(sessao => sessao.FilmeId == rsessao.FilmeId && sessao.CinemaId == rsessao.CinemaId);

        List<ReadSessaoDto> sessaoDto = new List<ReadSessaoDto>();
        foreach (var sessao in sessoes)
        {
            ReadSessaoDto rsessaoDto = new ReadSessaoDto
            {
                Id = sessao.Id,
                FilmeId = sessao.FilmeId,
                CinemaId = (int)sessao.CinemaId
            };

            sessaoDto.Add(rsessaoDto);
        }

        return sessaoDto;
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaSessaoPorId(int id)
    {
        Sessao sessao = _context.Sessoes.Include(s => s.Id).FirstOrDefault(s => s.Id == id);

        if (sessao != null)
        {
            ReadSessaoDto sessaoDto = new ReadSessaoDto
            {

                Id = sessao.Id
            };

            return Ok(sessaoDto);
        }

        return NotFound();
    }

    



}
