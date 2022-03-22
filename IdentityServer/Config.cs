using IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Security.Claims;

namespace IdentityServer;

public class Config
{
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new()
            {
                ClientId ="movieClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "movieAPI"} 
            },
            new()
            {
                ClientId = "movies_mvc_client",
                ClientName = "Movies MVC web app",
                AllowedGrantTypes  = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>
                {
                    "https://localhost:5002/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://localhost:5002/signout-callback-oidc"
                },
                ClientSecrets = new List<Secret>
                {
                    new("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };
    public static IEnumerable<ApiScope> ApiScopes =>
        new[] 
        {
            new ApiScope("movieAPI", "Movie API")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("movieAPI", "Movie API")
        };
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[] 
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    public static List<TestUser> TestUsers =>
        new()
        {
            new TestUser
            {
                SubjectId = "BB1F78DD-67A9-455E-86C7-22C8CF207254",
                Username = "tanlan",
                Password = "Pa$$w0rd",
                Claims = new List<Claim>
                {
                    new(JwtClaimTypes.GivenName, "Lan"),
                    new(JwtClaimTypes.FamilyName, "Bui Tan")
                }
            }
        };
}