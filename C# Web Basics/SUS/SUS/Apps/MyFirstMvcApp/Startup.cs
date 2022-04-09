using System.Collections.Generic;

using BattleCards.Data;
using BattleCards.Services;

using Microsoft.EntityFrameworkCore;

using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
