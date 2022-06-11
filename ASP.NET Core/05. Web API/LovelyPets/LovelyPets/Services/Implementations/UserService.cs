namespace LovelyPets.Services.Implementations
{
    using Contracts;
    using Data;
    using Jwt;
    using LovelyPets.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Models.InputModels;
    using Models.ViewModels;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly LovelyPetsDbContext context;
        private readonly JwtSettings jwtSettings;

        public UserService(LovelyPetsDbContext context, 
            IOptions<JwtSettings> jwtSettings)
        {
            this.context = context;
            this.jwtSettings = jwtSettings.Value;
        }

        public UserViewModel CreateUser(RegisterUserBindingModel model, string newEmail)
        {
            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.HashPassword(model.Password)
            };

            user.Email = newEmail;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            var userModel = new UserViewModel()
            {
                Username = user.Username,
                Email = user.Email
            };

            return userModel;
        }

        public string Authenticate(string username, string password)
        {
            var user = this.GetUserByUsernameAndPassword(username, password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        private User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = this.context
                .Users
                .FirstOrDefault(u => u.Username == username
                                     && u.Password == this.HashPassword(password));

            return user;
        }

        public User DeleteUserByUsername(string username)
        {
            var user = this.context
                .Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            this.context.Users.Remove(user);
            this.context.SaveChanges();

            return user;
        }
    }
}