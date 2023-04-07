using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]  
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id=0;

    [HttpPost]

    public void adicionarFilmes([FromBody]Filme filme)
    {
        filme.id = id++;

        filmes.Add(filme);
    }

    [HttpGet]
    public List<Filme> retornaFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? retornaFilmesId(int id)
    {
        return filmes.FirstOrDefault(filmes => filmes.id == id);

    }
}
