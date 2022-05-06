using System;
using System.Security.Cryptography;
using System.Text;

using Git.Data;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateUser(string username, string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameAvailable(string username)
        {
            throw new NotImplementedException();
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
