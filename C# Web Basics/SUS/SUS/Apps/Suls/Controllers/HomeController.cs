using Suls.ViewModels.Problems;
using System.Collections.Generic;

using SUS.HTTP;
using SUS.MvcFramework;
using Suls.Services;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var viewModel = this.problemsService.GetAll();
                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
