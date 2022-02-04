using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        [Required(ErrorMessage = "O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "O campo CinemaId é obrigatório")]
        public int CinemaId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

    }
}
