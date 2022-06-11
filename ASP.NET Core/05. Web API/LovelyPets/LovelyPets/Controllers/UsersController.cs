namespace LovelyPets.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.InputModels;
    using Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginUserBindingModel model)
        {
            var userToken = this.userService.Authenticate(model.Username, model.Password);

            if (userToken == null)
            {
                return this.BadRequest(new { message = "Username or password is incorrect" });
            }

            return this.Ok(userToken);
        }

        [HttpPost("register")]
        public IActionResult Register([FromQuery]RegisterUserBindingModel model, string newEmail)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Passwords doesn't match." });
            }

            this.userService.CreateUser(model, newEmail);

            return this.Ok(new { message = "User created."});
        }

        [HttpDelete("delete/{username}")]
        public IActionResult DeleteByUsername(string username)
        {
            var user = this.userService.DeleteUserByUsername(username);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { message = $"User ({user.Id}) delete." });
        }
    }
}