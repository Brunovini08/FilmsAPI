using System.Text.Json.Serialization;
using FilmsAPI.Models;

namespace FilmsAPI.Database.Dtos;

public class ReadFilmDto
{
    public string Title { get; set; }
    public int Duration { get; set; }
    public DateTime ConsultHour { get; set; } = DateTime.Now;
    public ICollection<ReadSectionDto> Sections { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryRoles CategoryRoles { get; set; }
}