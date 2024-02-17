using System.Collections.Specialized;
using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public SectionController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult PostSection(CreateSectionDto createSectionDto)
    {
        try
        {
            var section = _mapper.Map<Section>(createSectionDto);
            _context.Sections.Add(section);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSectionById), new { filmId = section.FilmId, movietheaterId = section.MovieTheaterId }, section);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    [HttpGet]
    public IEnumerable<ReadSectionDto> GetSection()
    {
        return _mapper.Map<List<ReadSectionDto>>(_context.Sections);
    }

    [HttpGet("{filmId}/{movietheaterId}")]
    public IActionResult GetSectionById(int filmid, int movietheaterId)
    {
        var section = _context.Sections.FirstOrDefault(section => section.FilmId == filmid && section.MovieTheaterId == movietheaterId);
        if (section == null) return NotFound();
        var sectionDto = _mapper.Map<ReadSectionDto>(section);
        return Ok(sectionDto);
    }

    [HttpDelete("{filmId}/{movietheaterId}")]
    public IActionResult DeleteSection(int filmid, int movietheaterId)
    {
        var section = _context.Sections.FirstOrDefault(section => section.FilmId == filmid && section.MovieTheaterId == movietheaterId);
        if (section == null) return NotFound();
        _context.Remove(section);
        _context.SaveChanges();
        return NoContent();
    }
}