using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class MovieTheater
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The field is required")] 
    public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Section> Sections { get; set; }
}