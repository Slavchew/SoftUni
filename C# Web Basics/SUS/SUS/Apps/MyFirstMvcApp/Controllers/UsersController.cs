using System;
using System.IO;
using System.Text;

using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse DoLogin(HttpRequest arg)
        {
            // TODO: read Data
            // TODO: check user
            // TODO: log user
            // TODO: home page
            return this.Redirect("/");
        }
    }
}
