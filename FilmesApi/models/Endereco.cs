using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Endereco
{
    [Key]
    [Required]
    public int id { get; set; }
    public string logradouro { get;set; }

    public int numero { get; set; }
    public virtual Cinema? Cinema { get; set; }
}
