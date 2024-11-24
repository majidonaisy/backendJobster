using backend.Data;
using backend.DTOs;
using backend.Models;
using BCrypt;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AuthService
    {
        private readonly AppDataContext _context;
        public AuthService(AppDataContext appDataContext)
        {
            _context = appDataContext;
        }
        public async Task<(bool Success, string Message, User? User)> RegisterUser(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(x => x.Email == request.Email))
            {
                return (false, "Email already exists", null);
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = hashedPassword,
                Name = request.Name,
                Role = request.Role,
            };

            _context.Users.Add(user);
            if (request.Role == "User")
            {
                var talentProfile = new TalentProfile { UserId = user.Id, };
                _context.TalentProfiles.Add(talentProfile);
            }
            else
            {
                var startupProfile = new StartupProfile { UserId = user.Id, };
                _context.StartupProfiles.Add(startupProfile);
            }
            await _context.SaveChangesAsync();
            return (true, "User registered successfully", user);

        }
    }
}
