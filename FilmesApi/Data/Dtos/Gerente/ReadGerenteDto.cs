using System;
using System.Collections.Generic;
using FilmesAPI.Models;

namespace FilmesApi.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual object Cinemas { get; set; }

        public ReadGerenteDto()
        {
        }
    }
}
