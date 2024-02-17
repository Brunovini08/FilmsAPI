using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profile;

public class SectionProfile: AutoMapper.Profile
{
    public SectionProfile()
    {
        CreateMap<CreateSectionDto, Section>();
        CreateMap<Section, ReadSectionDto>();
    }
}