using System.Text.Json.Serialization;
using FilmsAPI.Database;
using FilmsAPI.Profile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FilmConnection");

builder.Services.AddDbContext<FilmContext>(options =>
{
   options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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
