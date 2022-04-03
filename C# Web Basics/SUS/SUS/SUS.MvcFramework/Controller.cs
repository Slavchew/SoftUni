using System.Runtime.CompilerServices;
using System.Text;

using SUS.HTTP;
using SUS.MvcFramework.ViewEngine;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        public HttpRequest Request { get; set; }

        public HttpResponse View(object viewModel = null, [CallerMemberName] string viewPath = null)
        {
            var viewContent = System.IO.File.ReadAllText(
                "Views/" +
                this.GetType().Name.Replace("Controller", string.Empty) +
                "/" +
                viewPath +
                ".cshtml");

            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var layuot = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layuot = layuot.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layuot = this.viewEngine.GetHtml(layuot, viewModel);

            var responseHtml = layuot.Replace("____VIEW_GOES_HERE____", viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
