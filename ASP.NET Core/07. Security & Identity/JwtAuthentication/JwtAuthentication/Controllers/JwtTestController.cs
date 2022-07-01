using JwtAuthentication.Settings;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JwtTestController : ControllerBase
    {
        private readonly IOptions<JwtSettings> jwtSettings;

        public JwtTestController(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> WhoAmI()
        {
            return this.User.Identity.Name;
        }


        [HttpPost]
        public ActionResult<UserToken> Login(LoginInputModel input)
        {
            // Authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, input.Username.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                                             new SymmetricSecurityKey(key),
                                             SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenAsString = tokenHandler.WriteToken(token);

            return new UserToken { Token = tokenAsString };
        }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class UserToken
    {
        public string Token { get; set; }
    }
}
