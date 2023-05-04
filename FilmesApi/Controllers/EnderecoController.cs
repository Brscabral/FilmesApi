using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController: ControllerBase
{
    private FilmesContext _context;

    public EnderecoController(FilmesContext context)
    {
        _context = context; 
    }


    [HttpPost]
    public IActionResult CriaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = new Endereco()
        {
            logradouro = enderecoDto.logradouro,
            numero = enderecoDto.numero,
        };
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(retornaEnderecoPorId), new { id = endereco.id }, endereco);
    }

    [HttpGet]
    public IEnumerable<Endereco> retornaCinema() { return _context.Enderecos; }

    [HttpGet("{id}")]
    public IActionResult retornaEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        if(id == null)
        {
            return NotFound();
        }
        return Ok(endereco);

    }

    [HttpPut("{id}")]
    public IActionResult atualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto )
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        if (id == null)
        {
            return NotFound();
        }
        else
        {
            endereco.logradouro = enderecoDto.logradouro;
            endereco.numero = enderecoDto.numero;
            _context.SaveChanges();
            return NoContent();
        }
        
    }
    [HttpDelete("{id}")]

    public IActionResult DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        if(id == null)
        {
            return NotFound();
        }
        else
        {
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }



}
