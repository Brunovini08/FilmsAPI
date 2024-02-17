using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FilmsAPI.Database.Dtos;

public class CreateSectionDto
{
    [Required]
    public int FilmId { get; set; }
    [Required]
    public int MovieTheaterId { get; set; }
}