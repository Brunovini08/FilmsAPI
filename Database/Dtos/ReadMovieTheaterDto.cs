﻿using FilmsAPI.Models;

namespace FilmsAPI.Database.Dtos;

public class ReadMovieTheaterDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ReadAddressDto Address { get; set; }
    public ICollection<ReadSectionDto> Sections { get; set; }
}