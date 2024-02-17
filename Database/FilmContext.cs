using FilmsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Database;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> options)
        : base(options)

    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Section>()
            .HasKey(section => new
            {
                section.FilmId,
                section.MovieTheaterId
            });

        modelBuilder.Entity<Section>()
            .HasOne(section => section.MovieTheater)
            .WithMany(movieTheater => movieTheater.Sections)
            .HasForeignKey(section => section.MovieTheaterId);
        
        modelBuilder.Entity<Section>()
            .HasOne(section => section.Film)
            .WithMany(film => film.Sections)
            .HasForeignKey(section => section.FilmId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.MovieTheater)
            .WithOne(movietheater => movietheater.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<MovieTheater> MovieTheaters { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Section> Sections { get; set; }
}