using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class DeleteFilmeDto
{
    public string titulo { get; set; }

    public string genero { get; set; }

    public Int32 duracao { get; set; }
    public DateTime horaConsulta { get; set; } = DateTime.Now;
}
