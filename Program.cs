using System.Text.Json.Serialization;
using FilmsAPI.Database;
using FilmsAPI.Profile;
using Microsoft.EntityFrameworkCore;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
string? databaseConnection = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (string.IsNullOrEmpty(databaseConnection))
{
    throw new ApplicationException("A variável de ambiente CONNECTION_STRING não está definida.");
}

builder.Services.AddDbContext<FilmContext>(options =>
{
    options.UseLazyLoadingProxies().UseMySql(databaseConnection, new MySqlServerVersion(new Version(8, 0, 23)));
});


builder.Services.AddAutoMapper(typeof(FilmProfile));

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
