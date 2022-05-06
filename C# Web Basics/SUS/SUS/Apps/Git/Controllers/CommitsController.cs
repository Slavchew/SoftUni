using Git.Services;
using Git.ViewModels.Commits;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var viewModel = this.commitsService.GetAll(userId);

            return this.View(viewModel);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repositoryData = this.repositoriesService.GetRepositoryById(id);
            return this.View(repositoryData);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description is required and should be minimun 5 characters long.");
            }

            this.commitsService.Create(input.Description, input.Id, userId);
            return this.Redirect();
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var commit = this.commitsService.GetCommitById(id);

            if (userId != commit.CreatorId)
            {
                return this.Error("You are not the owner of this commit.");
            }

            this.commitsService.Delete(id);
            return this.Redirect("/Commits/All");
        }
    }
}
