using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Fotos;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class FotoService
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public FotoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get
        public List<ReadFotoDto> RecuperarGerentes()
        {
            List<Foto> fotos = _context.Fotos.ToList();
            if (fotos == null) return null;
            return _mapper.Map<List<ReadFotoDto>>(fotos);
        }

        //Get id
        public ReadFotoDto RecuperarGerentePorId(int id)
        {
            Foto foto = _context.Fotos.FirstOrDefault(foto => foto.Id == id);
            if (foto == null) return null;
            return _mapper.Map<ReadFotoDto>(foto);
        }

        //Post
        public ReadFotoDto AdicionarGerente(CreateFotoDto fotoDto)
        {
            Foto newFoto = _mapper.Map<Foto>(fotoDto);
            _context.Fotos.Add(newFoto);
            _context.SaveChanges();
            return _mapper.Map<ReadFotoDto>(newFoto);
        }
    }
}
