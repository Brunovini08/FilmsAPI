namespace FilmsAPI.Models;

public class CategoryFilms
{
    public int? FilmId { get; set; }
    public virtual Film Film { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
}