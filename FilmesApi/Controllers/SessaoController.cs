using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<ReadSessaoDto> sessaos = _sessaoService.RecuperarSessoes();
            if (sessaos == null) return NotFound();
            return Ok(sessaos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoId(int id)
        {
            ReadSessaoDto sessao = _sessaoService.RecuperarSessaoId(id);
            if (sessao == null) return NotFound();            
            return Ok(sessao);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto sessao = _sessaoService.AdicionarSessao(sessaoDto);
            if (sessao == null) return NotFound();            
            return CreatedAtAction(nameof(RecuperarSessaoId), new { Id = sessao.Id }, sessao);
        }
    }

}
