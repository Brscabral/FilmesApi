﻿using FilmesApi.Data.Dto;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Cinema
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required(ErrorMessage ="O campo de nome é obrigatorio")]
    [MaxLength(50)]
    public string nome { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; }

}
