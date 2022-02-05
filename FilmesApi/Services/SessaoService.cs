using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET
        public List<ReadSessaoDto> RecuperarSessoes()
        {
            List<Sessao> sessaos = _context.Sessoes.ToList();
            if (sessaos == null) return null;
            return _mapper.Map<List<ReadSessaoDto>>(sessaos);
        }

        public ReadSessaoDto RecuperarSessaoId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null) return null;
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }
    }
}
