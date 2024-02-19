using FilmsAPI.Database.Dtos;
using FilmsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : ControllerBase
{
    private SectionService _sectionService;

    public SectionController(SectionService sectionService)
    {
        _sectionService = sectionService;
    }
    
    [HttpPost]
    public IActionResult PostSection(CreateSectionDto createSectionDto)
    {
        var section = _sectionService.PostSection(createSectionDto);
        return CreatedAtAction(nameof(GetSectionById), new { filmId = section.FilmId, movietheaterId = section.MovieTheaterId }, section);
    }

    [HttpGet]
    public IActionResult GetSection()
    {
        var section = _sectionService.GetSection();
        return Ok(section);
    }

    [HttpGet("{filmId}/{movietheaterId}")]
    public IActionResult GetSectionById(int filmId, int movietheaterId)
    {
        var section = _sectionService.GetSectionById(filmId, movietheaterId);
        return Ok(section);
    }

    [HttpDelete("{filmId}/{movietheaterId}")]
    public IActionResult DeleteSection(int filmId, int movietheaterId)
    {
        _sectionService.DeleteSection(filmId, movietheaterId);
        return NoContent();
    }
}