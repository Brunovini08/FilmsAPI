using AutoMapper;
using FilmsAPI.Database;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController
{
    private FilmContext _context;
    private IMapper _mapper;

    public CategoryController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult PostCategory
}