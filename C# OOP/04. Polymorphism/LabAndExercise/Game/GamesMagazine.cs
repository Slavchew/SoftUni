using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class GamesMagazine
    {
        private List<Game> games;

        public GamesMagazine()
        {
            games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            games.Add(game);
        }

        public void StartGames()
        {
            foreach (var game in games)
            {
                game.Start();
            }
        }

        public void StopGames()
        {
            foreach (var game in games)
            {
                game.Stop();
            }
        }

        public void PrintDiscriptions()
        {
            foreach (var game in games)
            {
                Console.WriteLine(game.GetDiscription());
            }
        }
    }
}
