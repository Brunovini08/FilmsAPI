using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmsAPI.Models;

public enum CategoryRoles
{
    Action,
    Adventure,
    Comedy,
    Fiction,
    Horror,
    Romance
}
public class Film
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The films title is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "The film duration is required")]
    [Range(70, 600)]
    public int Duration { get; set; }
    public virtual ICollection<Section> Sections { get; set; }
    [Required]
    
    public CategoryRoles CategoryRoles { get; set; }
}