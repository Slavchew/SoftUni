using System.Runtime.CompilerServices;
using System.Text;

using SUS.HTTP;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string viewPath = null)
        {
            var layuot = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            var viewContent = System.IO.File.ReadAllText(
                "Views/" + 
                this.GetType().Name.Replace("Controller", string.Empty) + 
                "/" + 
                viewPath + 
                ".cshtml");

            var responseHtml = layuot.Replace("@RenderBody()", viewContent);

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
