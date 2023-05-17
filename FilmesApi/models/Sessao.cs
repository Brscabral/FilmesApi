﻿using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace FilmesApi.models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; } 
}
