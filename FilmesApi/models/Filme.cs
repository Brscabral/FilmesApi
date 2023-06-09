﻿using FilmesApi.Data.Dto;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models
{
    public class Filme
    {
        internal string nome;

        [Key]
        [Required]
        
        public int id { get; set; }

        [Required(ErrorMessage = "O parametro de titulo não pode ser vazio")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "O parametro de genero não pode ser vazio")]
        [MaxLength(50, ErrorMessage ="A duração da descrição não pode ultrapassar 50 caracteres")]
        public string genero { get; set; }
        [Required(ErrorMessage = "O parametro de duração não pode ser vazio")]
        [Range(70,600, ErrorMessage = "O filme não poderá ter uma duração menor do que 70 minutos ou maior que 600 minutos")]
        public Int32 duracao { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
        //public virtual ICollection<ReadSessaoDto> ReadSessoesDto { get; set; }


    }
}
