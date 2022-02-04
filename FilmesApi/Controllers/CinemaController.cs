using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaServices _cinemaServices;

        public CinemaController(CinemaServices cinemaServices)
        {
            _cinemaServices = cinemaServices;
        }

        [HttpGet] //LINQ
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> cinemas = _cinemaServices.RecuperaCinemas(nomeDoFilme);
            if (cinemas == null) return NotFound();
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto cinema = _cinemaServices.RecuperaCinemasPorId(id);
            if (cinema == null) return NotFound();
            return Ok(cinema);
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto cinema = _cinemaServices.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaServices.AtualizaCinema(id, cinemaDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = _cinemaServices.DeletaCinema(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
