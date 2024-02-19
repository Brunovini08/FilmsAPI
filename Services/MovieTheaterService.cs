using AutoMapper;
using FilmsAPI.Database;
using FilmsAPI.Database.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Services;

public class MovieTheaterService
{
    private FilmContext _context;
    private IMapper _mapper;

    public MovieTheaterService(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public MovieTheater PostMovieTheater(CreateMovieTheaterDto createMovieTheaterDto)
    {
        try
        {
            var movieTheater = _mapper.Map<MovieTheater>(createMovieTheaterDto);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return movieTheater;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<ReadMovieTheaterDto> GetMovieTheater(int? addressId = null)
    {
        try
        {
            if (addressId == null)
            {
                return _mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList());
            }

            return _mapper.Map<List<ReadMovieTheaterDto>>(
                _context.MovieTheaters.FromSqlRaw($"SELECT Id, Name, AddressId FROM movietheaters WHERE movietheaters.AddressId = {addressId}").ToList()
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ReadMovieTheaterDto GetMovieTheaterById(int id)
    {
        try
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater == null) return null!;
            var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
            return movieTheaterDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public MovieTheater UpdateMovieTheater(int id, UpdateMovieTheaterDto updateMovieTheaterDto)
    {
        try
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater == null) return null!;
            _mapper.Map(updateMovieTheaterDto, movieTheater);
            _context.SaveChanges();

            return movieTheater;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Boolean PatchMovieTheater(int id, JsonPatchDocument<UpdateMovieTheaterDto> patchMovieTheater, ModelStateDictionary modelState)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if (movieTheater == null)
        {
            modelState.AddModelError("Id", "MovieTheater not found");
            return false;
        }
        
        var updateMovieTheater = _mapper.Map<UpdateMovieTheaterDto>(movieTheater);
        patchMovieTheater.ApplyTo(updateMovieTheater, modelState);
        _context.SaveChanges();
        return true;
    }

    public string DeleteMovieTheater(int id)
    {
        try
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater == null) return null!;
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return "MovieTheater deleted";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}