using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class Section
{
    public int? FilmId { get; set; }
    public virtual Film Film { get; set; }
    public int? MovieTheaterId { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }
} 