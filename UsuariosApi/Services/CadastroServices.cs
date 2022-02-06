using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using FluentResults;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using System.Linq;

namespace UsuariosApi.Services
{
    public class CadastroServices
    {

        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager; //int = pq é um identificador inteiro
        private EmailService _emailService;

        public CadastroServices(
            IMapper mapper,
            UserManager<IdentityUser<int>> userMenager,
            EmailService emailService
            )
        {
            _userManager = userMenager;
            _mapper = mapper;
            _emailService = emailService;
        }

        //POST
        public Result CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            //Retornar uma tarefa, pois está executando uma
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                //Código de ativação do e-mail
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email},
                    "Link de ativação!", usuarioIdentity.Id, code);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário!");

        }

        //POST /ativa
        public Result AtivaContaUsuario(AtivaContaRequest ativaContaRequest)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(usuario => usuario.Id == ativaContaRequest.UsuarioId);
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, ativaContaRequest.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao ativar conta de usuário!");
        }
    }
}
