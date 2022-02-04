using System;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

        public DateTime HorarioDeInicio { get; set; }

    }
}
