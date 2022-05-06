using Git.Services;
using Git.ViewModels.Repositories;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var userId = this.GetUserId();
            var viewModel = this.repositoriesService.GetAll(userId);
            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (string.IsNullOrEmpty(input.Name) || input.Name.Length < 3 || input.Name.Length > 10)
            {
                return this.Error("Name is required and should be between 3 and 10 characters long.");
            }

            this.repositoriesService.Create(input.Name, input.RepositoryType, userId);
            return this.Redirect();
        }
    }
}
