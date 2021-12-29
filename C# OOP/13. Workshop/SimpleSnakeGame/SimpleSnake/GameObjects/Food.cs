using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;
        
        protected Food(Wall wall, char symbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            this.FoodPoints = foodPoints;
            this.Symbol = symbol;

            this.wall = wall;

            this.random = new Random();
        }

        public char Symbol { get; }
        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = this.random.Next(1, this.wall.LeftX - 1);
            this.TopY = this.random.Next(1, this.wall.TopY - 1);

            bool isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPartOfSnake)
            {
                this.LeftX = this.random.Next(1, this.wall.LeftX - 1);
                this.TopY = this.random.Next(1, this.wall.TopY - 1);

                isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.LeftX, this.TopY, this.Symbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake) 
            => snake.LeftX == this.LeftX && 
               snake.TopY == this.TopY;
    }
}
