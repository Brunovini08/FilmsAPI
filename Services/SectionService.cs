using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class SectionService
{
    private IMapper _mapper;
    private FilmContext _context;
    
    public SectionService(IMapper mapper, FilmContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Section PostSection(CreateSectionDto createSectionDto)
    {
        try
        {
            var section = _mapper.Map<Section>(createSectionDto);
            _context.Sections.Add(section);
            _context.SaveChanges();
            return section;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public IEnumerable<ReadSectionDto> GetSection()
    {
        return _mapper.Map<List<ReadSectionDto>>(_context.Sections);
    }

    public ReadSectionDto GetSectionById(int filmId, int movietheaterId)
    {
        try
        {
            var section = _context.Sections.FirstOrDefault(section => section.FilmId == filmId && section.MovieTheaterId == movietheaterId);
            if (section == null) return null!;
            var sectionDto = _mapper.Map<ReadSectionDto>(section);
            return sectionDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string DeleteSection(int filmId, int movietheaterId)
    {
        try
        {
            var section = _context.Sections.FirstOrDefault(section => section.FilmId == filmId && section.MovieTheaterId == movietheaterId);
            if (section == null) return null!;
            _context.Remove(section);
            _context.SaveChanges();
            return "Section deleted";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}