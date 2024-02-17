using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{

    private FilmContext _context;
    private IMapper _mapper;

    public AddressController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult PostAddress([FromBody] CreateAddressDto createAddressDto)
    {
        try
        {
            var address = _mapper.Map<Address>(createAddressDto);
            _context.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddress(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10
        )
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        var addressDto = _mapper.Map<ReadAddressDto>(address);
        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult PutAddress(int id, UpdateAddressDto updateAddressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        _mapper.Map(updateAddressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchAddress(int id, JsonPatchDocument<UpdateAddressDto> patchAddress)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        var updateAddress = _mapper.Map<UpdateAddressDto>(address);
        patchAddress.ApplyTo(updateAddress, ModelState);
        if (!TryValidateModel(updateAddress))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(updateAddress, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}