using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profile;

public class MovieTheaterProfile : AutoMapper.Profile
{
    public MovieTheaterProfile()
    {
        CreateMap<CreateMovieTheaterDto, MovieTheater>();
        CreateMap<UpdateMovieTheaterDto, MovieTheater>();
        CreateMap<MovieTheater, UpdateMovieTheaterDto>();
        CreateMap<MovieTheater, ReadMovieTheaterDto>()
            .ForMember(dto => dto.Address,
                opt => opt.MapFrom(theater => theater.Address))
            .ForMember(dto => dto.Sections,
                opt => opt.MapFrom(theater => theater.Sections));
    }
}