using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Database.Dtos;

public class UpdateAddressDto
{
    [Required]
    public string PublicPlace { get; set; }
    [Required]
    public int Number { get; set; }
}