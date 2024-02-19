using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilmsAPI.Services;

public class FilmService
{
    private IMapper _mapper;
    private FilmContext _context;

    public FilmService(IMapper mapper, FilmContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public Film PostFilm(CreateFilmDto createFilmDto)
    {
        try
        {
            var film = _mapper.Map<Film>(createFilmDto);
            _context.Films.Add(film);
            _context.SaveChanges();
            return film;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<ReadFilmDto> GetFilm(int skip, int take, string? movieTheaterName)
    {
        try
        {
            if (movieTheaterName == null)
            {
                return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).ToList());
            }

            return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).Where(film =>
                film.Sections.Any(section => section.MovieTheater.Name == movieTheaterName)).ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ReadFilmDto GetById(int id)
    {
        try
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return null!;
            var filmDto = _mapper.Map<ReadFilmDto>(film);
            return filmDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Film UpdateFilm(UpdateFilmDto updateFilmDto, int id)
    {
        try
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return null!;
            _mapper.Map(updateFilmDto, film);
            _context.SaveChanges();
            return film;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Boolean PatchFilm(int id, JsonPatchDocument<UpdateFilmDto> filmPath, ModelStateDictionary modelState )
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null)
        {
            modelState.AddModelError("Id", "Film not found");
            return false;
        }

        var updateFilm = _mapper.Map<UpdateFilmDto>(film);
        filmPath.ApplyTo(updateFilm, modelState);
        _context.SaveChanges();
        return true;
    }

    public string DeleteFilm(int id)
    {
        try
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return null!;
            _context.Remove(film);
            _context.SaveChanges();
            return "Film deleted";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}