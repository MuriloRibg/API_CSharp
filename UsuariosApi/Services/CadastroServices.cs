using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using FluentResults;
using System.Threading.Tasks;

namespace UsuariosApi.Services
{
    public class CadastroServices
    {

        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userMenager; //int = pq é um identificador inteiro

        public CadastroServices(IMapper mapper, UserManager<IdentityUser<int>> userMenager)
        {
            _userMenager = userMenager;
            _mapper = mapper;
        }

        //POST
        public Result CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            //Retornar uma tarefa, pois está executando uma
            Task<IdentityResult> resultadoIdentity = _userMenager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário!");

        }
    }
}
