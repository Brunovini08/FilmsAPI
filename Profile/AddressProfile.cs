using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profile;

public class AddressProfile : AutoMapper.Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateFilmDto, Address>();
        CreateMap<Address, UpdateFilmDto>();
        CreateMap<Address, ReadAddressDto>();
    }
}