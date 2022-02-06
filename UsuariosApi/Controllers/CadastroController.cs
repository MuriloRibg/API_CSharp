using System;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroServices _cadastroSevices;

        public CadastroController(CadastroServices cadastroSevices)
        {
            _cadastroSevices = cadastroSevices;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Result result = _cadastroSevices.CadastrarUsuario(createDto);
            if (result.IsFailed) return StatusCode(500); //500 = erro interno
            return Ok(result.Successes);
        }

        [HttpPost("/ativa")]
        public IActionResult AtivaContaUsuario(AtivaContaRequest ativaContaRequest)
        {
            Result result = _cadastroSevices.AtivaContaUsuario(ativaContaRequest);
            if (result.IsFailed) return StatusCode(500); //Error interno
            return Ok(result.Successes);
        }
    }
}
