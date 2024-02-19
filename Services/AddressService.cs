using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilmsAPI.Services;

public class AddressService
{
    private IMapper _mapper;
    private FilmContext _context;

    public AddressService(IMapper mapper, FilmContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Address PostAddress(CreateAddressDto createAddressDto)
    {
        try
        {
            var address = _mapper.Map<Address>(createAddressDto);
            _context.Add(address);
            _context.SaveChanges();
            return address;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<ReadAddressDto> GetAddress(int skip, int take)
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.Skip(skip).Take(take));
    }

    public ReadAddressDto GetAddressById(int id)
    {
        try
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return null!;
            var addressDto = _mapper.Map<ReadAddressDto>(address);
            return addressDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Address PutAddress(int id, UpdateAddressDto updateAddressDto)
    {
        try
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return null!;
            _mapper.Map(updateAddressDto, address);
            _context.SaveChanges();
            return address;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Boolean PatchAddress(int id, JsonPatchDocument<UpdateAddressDto> patchAddress, ModelStateDictionary modelState)
    {
        try
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                modelState.AddModelError("Id", "Address not found");
                return false;
            }

            var updateAddress = _mapper.Map<UpdateAddressDto>(address);
            patchAddress.ApplyTo(updateAddress, modelState);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string DeleteAddress(int id)
    {
        try
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return null!;
            _context.Remove(address);
            _context.SaveChanges();
            return "Address deleted";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}