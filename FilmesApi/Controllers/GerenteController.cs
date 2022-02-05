using System.Collections.Generic;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            List<ReadGerenteDto> readGerenteDto = _gerenteService.RecuperarGerentes();
            if (readGerenteDto == null) return NotFound();
            return Ok(readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperarGerentePorId(id);
            if (readGerenteDto == null) return NotFound();
            return Ok(readGerenteDto);

        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto gerente = _gerenteService.AdicionarGerente(gerenteDto);
            if (gerente == null) return NotFound();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDto updateGerenteDto)
        {
            Result result = _gerenteService.AtualizarGerente(id, updateGerenteDto);
            if (result.IsFailed) return NotFound(result.Errors);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result result = _gerenteService.DeletarGerente(id);
            if (result.IsFailed) return NotFound(result.Errors);
            return NoContent();
        }
    }
}
