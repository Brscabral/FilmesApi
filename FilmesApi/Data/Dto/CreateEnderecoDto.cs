using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto
{
    public class CreateEnderecoDto
    {
       
        public string logradouro { get; set; }

        public int numero { get; set; }
    }
}
