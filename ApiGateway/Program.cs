using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

const string authenticationProviderKey = "IdentityApiKey";
var configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot(configuration);
builder.Services.AddAuthentication()
    .AddJwtBearer(authenticationProviderKey, x =>
    {
        x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
        //x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

var app = builder.Build();
app.UseOcelot();
app.MapControllers();
app.Run();