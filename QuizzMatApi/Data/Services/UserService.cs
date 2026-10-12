using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using QuizzMatApi.Data.BaseModels;
using QuizzMatApi.Data.BaseModelsContext;
using QuizzMatLib.Dtos;


namespace QuizzMatApi.Data.Services
{
    public class UserService
    {
        private readonly BaseModelContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(BaseModelContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApiResult> ChangePasswordAsync(ChangePasswordDto dto, int userId)
        {
            try
            {
                if (dto.NewPassword != dto.ConfirmNewPassword)
                    return ApiResult.Fail("Passwords do not match");

                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return ApiResult.Fail("User not found");

                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.CurrentPassword)
                    == PasswordVerificationResult.Failed)
                    return ApiResult.Fail("Current password is incorrect");

                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.NewPassword)
                    != PasswordVerificationResult.Failed)
                    return ApiResult.Fail("New password cannot be the same as the current one");

                user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ApiResult.Success();

            }
            catch (DbUpdateException)
            {
                return ApiResult.Fail("Failed to update password");
            }
        }
        public async Task<ApiResult> ChangeEmailAsync(ChangeEmailDto dto, int userId)
        {
            try
            {
                var newEmail = dto.NewEmail.Trim().ToLowerInvariant();
                var confirmEmail = dto.ConfirmNewEmail.Trim().ToLowerInvariant();

                if (newEmail != confirmEmail)
                    return ApiResult.Fail("Emails do not match");

                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return ApiResult.Fail("User not found");

                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.CurrentPassword)
                    == PasswordVerificationResult.Failed)
                    return ApiResult.Fail("Current password is incorrect");

                if (string.Equals(user.Email, newEmail, StringComparison.OrdinalIgnoreCase))
                    return ApiResult.Fail("New email cannot be the same as the current email");

                if (await _context.Users.AnyAsync(u => u.Email.ToLower() == newEmail && u.Id != userId))
                    return ApiResult.Fail("Email is already in use");

                user.Email = newEmail;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ApiResult.Success();
            }
            catch (DbUpdateException)
            {
                return ApiResult.Fail("Failed to update email");
            }
        }
    }
}
