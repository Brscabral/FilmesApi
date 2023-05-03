using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatorio")]
    [MaxLength(50)]
    public string nome { get; set; }
}
