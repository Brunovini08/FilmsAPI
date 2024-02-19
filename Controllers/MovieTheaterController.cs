using FilmsAPI.Database.Dtos;
using FilmsAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private MovieTheaterService _movieTheaterService;

    public MovieTheaterController(MovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }
    [HttpPost]
    public IActionResult PostMovieTheater([FromBody] CreateMovieTheaterDto createMovieTheaterDto)
    {
        var movieTheater = _movieTheaterService.PostMovieTheater(createMovieTheaterDto);
        return CreatedAtAction(nameof(GetMovieTheaterById),
            new { id = movieTheater.Id }, movieTheater);
    }

    [HttpGet]
    public IActionResult GetMovieTheater([FromQuery] int? addressId = null)
    {
        var movieTheater = _movieTheaterService.GetMovieTheater(addressId);
        return Ok(movieTheater);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieTheaterById(int id)
    {
        var movieTheater = _movieTheaterService.GetMovieTheaterById(id);
        return Ok(movieTheater);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto updateMovieTheaterDto)
    {
        _movieTheaterService.UpdateMovieTheater(id, updateMovieTheaterDto);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMovieTheater(int id, JsonPatchDocument<UpdateMovieTheaterDto> movieTheaterPath)
    {
        var sucess = _movieTheaterService.PatchMovieTheater(id, movieTheaterPath, ModelState);
        if (!sucess)
        {
            return ValidationProblem(ModelState);
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        _movieTheaterService.DeleteMovieTheater(id);
        return NoContent();
    }
}