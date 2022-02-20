using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //POST
        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                //Recuperando o usuario
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService
                    .CreateToken(identityUser, _signInManager
                                .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                //retornando o token para o controller
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou!");
        }

        //POST solicita-reset
        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);         
            if (identityUser == null) return Result.Fail("Falha ao solicitar redefinação!");

            string codigoDeRecuperacao = _signInManager
                .UserManager
                .GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }

        //POTS efetua-reset
        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser == null) return Result.Fail("Falha ao solicitar redefinação!");

            IdentityResult identityResult = _signInManager
                .UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (identityResult.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na operação!");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail( string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(usuario => usuario.NormalizedEmail == email.ToUpper());
        }
    }
}
