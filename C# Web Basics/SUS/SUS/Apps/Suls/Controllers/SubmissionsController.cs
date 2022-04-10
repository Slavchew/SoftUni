using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Suls.Services;
using Suls.ViewModels.Submissions;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                Name = this.problemsService.GetNameById(id),
                ProblemId = id,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            var userId = this.GetUserId();

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code is required and should be between 30 and 800 characters long.");
            }

            this.submissionsService.Create(problemId, userId, code);

            return this.Redirect();
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect();
        }
    }
}
