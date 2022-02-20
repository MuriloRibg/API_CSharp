using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Foto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Url é obrigatório!")]
        public string Url { get; set; }

        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "O campo Description é obrigatório!")]
        public string Description { get; set; }

        public bool? AllowComments { get; set; }

        [Required(ErrorMessage = "O campo Likes é obrigatório!")]
        public int Likes { get; set; }

        [Required(ErrorMessage = "O campo Comments é obrigatório!")]
        public int Comments { get; set; }

        public int? UserId { get; set; }
    }
}
