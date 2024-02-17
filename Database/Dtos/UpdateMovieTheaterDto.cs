using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Database.Dtos;

public class UpdateMovieTheaterDto
{
    [Required(ErrorMessage = "The field is required")]
    public string Name { get; set; }
}