using QuizzMatLib.Dtos;
using QuizzMatApi.Data.Services;

namespace QuizzMatApi.EndPoints
{
    public class AuthEndpoint
    {
        public static IEndpointBuilder MapAuthEndpoint(this IEndpointRouteBuilder app)
        {
            var authGroup = app.MapGroup("/api/auth").WithTags("Auth");

            authGroup.MapPost("/register", async (RegisterDto dto, AuthService service) =>
            {
                return Results.Ok(await service.RegisterAsync(dto));
            })
                .Produces<ApiResult>()
                .WithName("Register");

            authGroup.MapPost("/login", async (LoginDto dto, AuthService service) =>
            {
                return Results.Ok(await service.LoginAsync(dto));
            })
                .Produces<ApiResult<LoggedInUser>>()
                .WithName("Login");

            return app;
        }
    }
}
