namespace SimpleSnake
{
    using System;
    using System.IO;
    using Utilities;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall, 1, 6);

            Engine engine = new Engine(snake, wall);
            Console.SetCursorPosition(0, wall.TopY + 3);
            
            var result = File.ReadAllLines("../../../Database/scores.txt")
                .OrderByDescending(x => int.Parse(x.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1]))
                .Take(10);

            Console.WriteLine("ScoreBoard(Top 10):");
            Console.WriteLine(string.Join(Environment.NewLine, result));


            engine.Run();
        }
    }
}
