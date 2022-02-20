using System;
using System.Collections.Generic;
using FilmesApi.Data.Dtos.Fotos;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FotoController : ControllerBase
    {
        private FotoService _fotoService;

        public FotoController(FotoService fotoService)
        {
            _fotoService = fotoService;
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            List<ReadFotoDto> readFotoDto = _fotoService.RecuperarGerentes();
            if (readFotoDto == null) return NotFound();
            return Ok(readFotoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFotoPorId(int id)
        {
            ReadFotoDto readGerenteDto = _fotoService.RecuperarGerentePorId(id);
            if (readGerenteDto == null) return NotFound();
            return Ok(readGerenteDto);

        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateFotoDto fotoDto)
        {
            ReadFotoDto foto = _fotoService.AdicionarGerente(fotoDto);
            if (foto == null) return NotFound();
            return CreatedAtAction(nameof(RecuperaFotoPorId), new { Id = foto.Id }, foto);
        }

    }
}
