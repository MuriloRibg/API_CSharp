using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET
        public List<ReadGerenteDto> RecuperarGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes == null) return null;
            return _mapper.Map<List<ReadGerenteDto>>(gerentes);            
        }

        //GET ID
        public ReadGerenteDto RecuperarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return null;
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        //POST   
        public ReadGerenteDto AdicionarGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        //PUT
        public Result AtualizarGerente(int id, UpdateGerenteDto updateGerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return Result.Fail("Gerente não encontrado!");
            _mapper.Map(updateGerenteDto, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        //DELETE
        public Result DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return Result.Fail("Gerente não encontrado!");
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
