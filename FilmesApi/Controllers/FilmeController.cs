using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeServices _filmeService;

        public FilmeController(FilmeServices filmeServices)
        {
            _filmeService = filmeServices;
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readFilmeDtos = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readFilmeDtos == null) return NotFound();
            return Ok(readFilmeDtos);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperaFilmesPorId(id);
            if (readFilmeDto == null) return NotFound();
            return Ok(readFilmeDto);

        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto filme = _filmeService.AdicionarFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.AtualizarFilme(id, filmeDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result result = _filmeService.DeletaFilme(id);
            if (result.IsFailed) return NotFound();           
            return NoContent();
        }

    }
}