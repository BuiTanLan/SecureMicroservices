using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesAPIContext")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() {Title = "Movies.API", Version = "v1"}); });

var app = builder.Build();

// Seed data
using var scope = app.Services.CreateScope();
var moviesContext = scope.ServiceProvider.GetService<MoviesContext>();
MoviesContextSeed.SeedAsync(moviesContext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();