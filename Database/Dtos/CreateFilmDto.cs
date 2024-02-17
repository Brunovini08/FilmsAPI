using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmsAPI.Models;

namespace FilmsAPI.Database.Dtos;

public class CreateFilmDto
{
    [Required(ErrorMessage = "The films title is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "The film duration is required")]
    [Range(70, 600)]
    public int Duration { get; set; }
    [Required(ErrorMessage = "The film category is required")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryRoles CategoryRoles { get; set; }
}