using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Database.Dtos;

public class CreateAddressDto
{
    [Required]
    public string PublicPlace { get; set; }
    [Required]
    public int Number { get; set; }
}