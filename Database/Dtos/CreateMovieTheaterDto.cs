using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FilmsAPI.Database.Dtos;

public class CreateMovieTheaterDto
{
    [Required(ErrorMessage = "The field is required")]
    public string Name { get; set; }
    public int AddressId { get; set; }
    
}