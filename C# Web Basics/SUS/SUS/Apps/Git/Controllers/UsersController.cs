using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
