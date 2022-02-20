using System;
using AutoMapper;
using FilmesApi.Data.Dtos.Fotos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {
            CreateMap<CreateFotoDto, Foto>();
            CreateMap<Foto, ReadFotoDto>();
        }
    }
}
