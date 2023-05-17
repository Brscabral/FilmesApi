namespace FilmesApi.Data.Dto;

public class ReadFilmeDto
{
    public string titulo { get; set; }

    public string genero { get; set; }

    public Int32 duracao { get; set; }
    public  ICollection<ReadSessaoDto> Sessoes { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
