using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string PublicPlace { get; set; }
    [Required]
    public int Number { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }
}