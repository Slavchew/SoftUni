namespace LovelyPets.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class BaseController : ControllerBase
    {
        public string GetCurrentLoggedInUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}