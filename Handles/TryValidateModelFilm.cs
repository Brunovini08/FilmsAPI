namespace FilmsAPI.Handles;

public class TryValidateModelFilm
{
    public virtual bool TryValidateModelFilmId(
        object model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return TryValidateModelFilmId(model);
    }
}