using System.ComponentModel.DataAnnotations;

using SharedTrip.Services;
using SharedTrip.ViewModels.Users;

using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrEmpty(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrEmpty(input.Username) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid Email.");
            }

            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 6 and 20 characters long.");
            }

            if (input.ConfirmPassword != input.Password)
            {
                return this.Error("Passwords do not match.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken.");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect();
        }
    }
}
