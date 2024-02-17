using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FilmsAPI.Models;

public class Category
{
    [Key]
    [Required] 
    public int Id { get; set; }
    [Required]
    public CategoryRoles CategoryRoles { get; set; }
}

