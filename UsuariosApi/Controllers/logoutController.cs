using System;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class logoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public logoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result result = _logoutService.DeslogaUsuario();
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);  
        }
    }
}
