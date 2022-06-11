namespace LovelyPets.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.InputModels;
    using Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PetsController : BaseController
    {
        private readonly IPetService petService;

        public PetsController(IPetService petService)
        {
            this.petService = petService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all")]
        public IActionResult All()
        {
            var allPets = this.petService.All();

            return this.Ok(allPets);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CreatePetBindingModel model)
        {
            var userId = this.GetCurrentLoggedInUserId();
            var pet = this.petService.Create(model, userId);

            if (pet == null)
            {
                return this.BadRequest(new { message = "Wrong user's token." });
            }

            return this.Ok(pet);
        }

        [HttpPut("love")]
        public IActionResult Love([FromQuery]string name)
        {
            var userId = this.GetCurrentLoggedInUserId();
            var pet = this.petService.GiveLove(name, userId);

            if (pet == null)
            {
                return this.BadRequest(new { message = "No such pet." });
            }

            return this.Ok(pet);
        }

        [HttpDelete("remove")]
        public IActionResult Remove([FromQuery]string name)
        {
            var userId = this.GetCurrentLoggedInUserId();
            var petName = this.petService.Delete(name, userId);

            if (petName == null)
            {
                return this.BadRequest(new {message = "No such pet."});
            }

            return this.Ok(new { message = $"Pet {petName} is removed."});
        }
    }
}