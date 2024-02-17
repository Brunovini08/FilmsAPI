using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult PostFilm(
        [FromBody] CreateFilmDto createFilmDto
        )
    {
        try
        {
            var film = _mapper.Map<Film>(createFilmDto);
            _context.Films.Add(film);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmById),
                new { id = film.Id },
                film);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public IEnumerable<ReadFilmDto> GetFilm(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10,
        [FromQuery] string? movieTheaterName = null
        )
    {
        if (movieTheaterName == null)
        {
            return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).Where(film =>
            film.Sections.Any(section => section.MovieTheater.Name == movieTheaterName)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmById(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        var filmDto = _mapper.Map<ReadFilmDto>(film);
        return Ok(filmDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDto filmDto)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) NotFound();
        _mapper.Map(filmDto, film);
        _context.SaveChanges();
        return NoContent();
        
    }

    [HttpPatch("{id}")]
    public IActionResult PatchFilm(int id, JsonPatchDocument<UpdateFilmDto> filmPath)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();

        var updateFilm = _mapper.Map<UpdateFilmDto>(film);
        filmPath.ApplyTo(updateFilm, ModelState);

        if (!TryValidateModel(updateFilm))
        {
            return ValidationProblem(ModelState);
        }
        
        _mapper.Map(updateFilm, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        _context.Remove(film);
        _context.SaveChanges();
        return NoContent();
    }
}