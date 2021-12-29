using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GamesMagazine games = new GamesMagazine();
            games.AddGame(new FootballGame());
            games.AddGame(new ChessGame(
                new Player("Fisher"), new Player("Spassky")));
            games.AddGame(new TennisGame(
                new Player("Nadal"), new Player("Federer")));

            games.StartGames();
            games.StopGames();
            games.PrintDiscriptions(); 
        }
    }
}
