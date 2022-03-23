using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.API.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, lc) => lc.WriteTo.Console());
builder.Services.AddSqlServer<MoviesContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => 
{ 
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movies.API", 
        Version = "v1"
    }); 
});
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5005";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id","movieClient", "movies_mvc_client"));
});
var app = builder.Build();

// Seed data
using var scope = app.Services.CreateScope();
var moviesContext = scope.ServiceProvider.GetService<MoviesContext>();
await moviesContext!.Database.MigrateAsync();
await MoviesContextSeed.SeedAsync(moviesContext);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();