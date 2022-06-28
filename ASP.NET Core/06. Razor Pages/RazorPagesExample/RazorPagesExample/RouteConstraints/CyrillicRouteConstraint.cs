using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RazorPagesExample.RouteConstraints
{
    public class CyrillicRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values.FirstOrDefault(x => x.Key == routeKey).Value.ToString();
            if (value == null)
            {
                return false;
            }

            var allowedCharacters = "абвгдежзийклмнопрстуфхцчшщъьюяэ";

            foreach (var ch in value)
            {
                if (!allowedCharacters.Contains(char.ToLower(ch)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
