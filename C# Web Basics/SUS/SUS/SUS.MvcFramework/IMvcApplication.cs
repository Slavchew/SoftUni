using System.Collections.Generic;

using SUS.HTTP;

namespace SUS.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
