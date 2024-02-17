using System.ComponentModel.DataAnnotations;
using FilmsAPI.Models;

namespace FilmsAPI.Database.Dtos;

public class UpdateFilmDto
{
    [Required(ErrorMessage = "The films title is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "The film duration is required")]
    [Range(70, 600)]
    public int Duration { get; set; }
    public CategoryRoles CategoryRoles { get; set; }
}