using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizzMatApi.Data.BaseModels;
using QuizzMatApi.Data.BaseModelsContext;
using QuizzMatLib.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizzMatApi.Data.Services
{
    public class AuthService
    {
        private readonly BaseModelContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(BaseModelContext context,  IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<ApiResult> RegisterAsync(RegisterDto dto)
        {
            if(await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return ApiResult.Fail("Email already exist");
            }
            if(await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
            {
                return ApiResult.Fail("Username already taken");
            }

            var user = new User
            {
                Email = dto.Email,
                Mobile = dto.Mobile,
                UserName = dto.UserName,
                DisplayName = dto.DisplayName
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return ApiResult.Success();
            }
            catch (Exception ex) 
            {
                return ApiResult.Fail(ex.Message);
            }

        }
        public async Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto)        
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
            {
                return ApiResult<LoggedInUser>.Fail("User does not exist");
            }

            var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if(verification != PasswordVerificationResult.Success)
            {
                return ApiResult<LoggedInUser>.Fail("Incorrect password");
            }

            var jwt = GenerateToken(user);
            var loggedInUser = new LoggedInUser(user.Id, user.UserName, user.Email, jwt);
            return ApiResult<LoggedInUser>.Success(loggedInUser);
        }


        private string GenerateToken(User user)
        {
            var secretKey = _configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("Jwt:SecretKey is not configured");
            var issuer = _configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("Jwt:Issuer is not configured");
            var audience = _configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("Jwt:Audience is not configured");
            var expireInMinutes = _configuration.GetValue("Jwt:ExpireInMinutes", 60);

            Claim[] claims =
            [
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.UserName),
        new(ClaimTypes.Email, user.Email)
            ];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCreds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
                signingCredentials: signingCreds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
