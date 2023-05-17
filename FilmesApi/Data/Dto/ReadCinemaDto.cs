namespace FilmesApi.Data.Dto;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string nome { get; set; }
    public int EnderecoId { get; set; }
    public DateTime TempoDaConsulta = DateTime.Now;
    public ReadeEnderecoDto ReadEnderecoDto { get; set; }
    public ICollection<ReadSessaoDto> ReadSessaoDto { get; set;}
}
