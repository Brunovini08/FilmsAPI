using AutoMapper;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profile;

public class FilmProfile : AutoMapper.Profile
{
   public FilmProfile()
   {
      CreateMap<CreateFilmDto, Film>();
      CreateMap<UpdateFilmDto, Film>();
      CreateMap<Film, UpdateFilmDto>();
      CreateMap<Film, ReadFilmDto>()
         .ForMember(dto => dto.Sections,
            opt => opt.MapFrom(film => film.Sections));
   }
}