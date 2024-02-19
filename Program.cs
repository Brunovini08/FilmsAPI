using System.Text.Json.Serialization;
using FilmsAPI.Database;
using FilmsAPI.Profile;
using Microsoft.EntityFrameworkCore;
using dotenv.net;
using FilmsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
string? databaseConnection = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (string.IsNullOrEmpty(databaseConnection))
{
    throw new ApplicationException("The environment variable is not defined");
}

builder.Services.AddDbContext<FilmContext>(options =>
{
    options.UseLazyLoadingProxies().UseMySql(databaseConnection, new MySqlServerVersion(new Version(8, 0, 23)));
});


builder.Services.AddAutoMapper(typeof(FilmProfile));
builder.Services.AddScoped<FilmService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<MovieTheaterService>();
builder.Services.AddScoped<SectionService>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}).AddNewtonsoftJson();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
