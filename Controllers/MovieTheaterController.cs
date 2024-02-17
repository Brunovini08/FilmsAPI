using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public MovieTheaterController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostMovieTheater([FromBody] CreateMovieTheaterDto createMovieTheaterDto)
    {
        try
        {
            var movieTheater = _mapper.Map<MovieTheater>(createMovieTheaterDto);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieTheaterById),
                new { id = movieTheater.Id }, movieTheater);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public IEnumerable<ReadMovieTheaterDto> GetMovieTheater([FromQuery] int? addressId = null)
    {
        if (addressId == null)
        {
            return _mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList());
        }

        return _mapper.Map<List<ReadMovieTheaterDto>>(
            _context.MovieTheaters.FromSqlRaw($"SELECT Id, Name, AddressId FROM movietheaters WHERE movietheaters.AddressId = {addressId}").ToList()
            );
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieTheaterById(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if (movieTheater == null) return NotFound();
        var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
        return Ok(movieTheaterDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto updateMovieTheaterDto)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if (movieTheater == null) return NotFound();
        _mapper.Map(updateMovieTheaterDto, movieTheater);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMovieTheater(int id, JsonPatchDocument<UpdateMovieTheaterDto> movieTheaterPath)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if (movieTheater == null) return NotFound();
        var updateMovieTheater = _mapper.Map<UpdateMovieTheaterDto>(movieTheater);
        movieTheaterPath.ApplyTo(updateMovieTheater, ModelState);
        if (!TryValidateModel(updateMovieTheater))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(updateMovieTheater, movieTheaterPath);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if (movieTheater == null) return NotFound();
        _context.Remove(movieTheater);
        _context.SaveChanges();
        return NoContent();
    }
}