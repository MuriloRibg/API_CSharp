using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesApi.Services
{
    public class CinemaServices
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET
        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null) return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        //GET ID
        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }

        //POST
        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        //PUT
        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return Result.Fail("Cinema não encontrado!");
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        //DELETE
        public Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado!");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
