using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using FluentResults;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using System.Linq;
using System.Web;

namespace UsuariosApi.Services
{
    public class CadastroServices
    {

        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager; //int = pq é um identificador inteiro
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroServices(
            IMapper mapper,
            UserManager<IdentityUser<int>> userMenager,
            EmailService emailService,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userMenager;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        //POST
        public Result CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            //Retornar uma tarefa, pois está executando uma
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);

            var createRoleResult = _roleManager
                .CreateAsync(new IdentityRole<int>("admin")).Result;

            if (resultadoIdentity.Result.Succeeded)
            {
                //Código de ativação do e-mail
                var code = _userManager
                   .GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                     "Link de Ativação", usuarioIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário!");

        }

        //POST /ativa
        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
