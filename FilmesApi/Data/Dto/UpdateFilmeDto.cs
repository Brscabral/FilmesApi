using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "O parametro de titulo não pode ser vazio")]
    public string titulo { get; set; }
    [Required(ErrorMessage = "O parametro de genero não pode ser vazio")]
    [StringLength(50, ErrorMessage = "A duração da descrição não pode ultrapassar 50 caracteres")]
    public string genero { get; set; }
    [Required(ErrorMessage = "O parametro de duração não pode ser vazio")]
    [Range(70, 600, ErrorMessage = "O filme não poderá ter uma duração menor do que 70 minutos ou maior que 600 minutos")]
    public Int32 duracao { get; set; }
}
