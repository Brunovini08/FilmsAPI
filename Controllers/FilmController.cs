using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{

    private FilmService _filmService;

    public FilmController(FilmService filmService)
    {
        _filmService = filmService;
    }
    
    [HttpPost]
    public IActionResult PostFilm(
        [FromBody] CreateFilmDto createFilmDto
        )
    {
        var film = _filmService.PostFilm(createFilmDto);
        return Ok(film);
    }

    [HttpGet]
    public IActionResult GetFilm(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10,
        [FromQuery] string? movieTheaterName = null
        )
    {
        var getFilms = _filmService.GetFilm(skip, take, movieTheaterName);
        return Ok(getFilms);
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmById(int id)
    {
        var film = _filmService.GetById(id);
        return Ok(film);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDto updateFilmDto)
    {
        _filmService.UpdateFilm(updateFilmDto, id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchFilm(int id, JsonPatchDocument<UpdateFilmDto> filmPath)
    {
        var success = _filmService.PatchFilm(id, filmPath, ModelState);
        if (!success)
        {
            return ValidationProblem(ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        _filmService.DeleteFilm(id);
        return NoContent();
    }
}