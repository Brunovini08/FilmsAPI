using FilmsAPI.Database.Dtos;
using FilmsAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{

    private AddressService _addressService;
    

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }
    
    [HttpPost]
    public IActionResult PostAddress([FromBody] CreateAddressDto createAddressDto)
    {
        var address = _addressService.PostAddress(createAddressDto);
        return Ok(address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddress(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10
        )
    {
        return _addressService.GetAddress(skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        var address = _addressService.GetAddressById(id);
        return Ok(address);
    }

    [HttpPut("{id}")]
    public IActionResult PutAddress(int id, UpdateAddressDto updateAddressDto)
    {
        _addressService.PutAddress(id, updateAddressDto);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchAddress(int id, JsonPatchDocument<UpdateAddressDto> patchAddress)
    {
        var success = _addressService.PatchAddress(id, patchAddress, ModelState);
        if (!success)
        {
            return ValidationProblem(ModelState);
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        _addressService.DeleteAddress(id);
        return NoContent();
    }
}