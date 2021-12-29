using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char snakeSymbol = '\u25CF';

        private readonly Food[] foods;
        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;

        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY) 
            : base(leftX, topY)
        {
            this.wall = wall;

            this.snakeElements = new Queue<Point>();
            this.foods = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall)
            };
            this.CreateSnake();

            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                Point point = new Point(this.LeftX + i, this.TopY);
                point.Draw(snakeSymbol);

                snakeElements.Enqueue(point);
            }
        }

        public int Length
            => this.snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextDirection(direction, currentSnakeHead);

            if (IsWallPoint())
            {
                return false;
            }


            if (IsPartOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.foods[foodIndex].IsFoodPoint(newHead))
            {
                Eat(direction, newHead);
            }

            RemoveTail();

            return true;
        }

        private bool IsWallPoint()
        {
            return this.LeftX == 0 || this.TopY == 0 ||
                            this.LeftX == this.wall.LeftX ||
                            this.TopY == this.wall.TopY;
        }

        private Point CreateNewHead()
        {
            Point newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(snakeSymbol);
            this.snakeElements.Enqueue(newHead);
            return newHead;
        }

        private void RemoveTail()
        {
            Point tail = this.snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.foods[foodIndex].FoodPoints; i++)
            {
                this.GetNextDirection(direction, newHead);

                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(snakeSymbol);

                this.snakeElements.Enqueue(newHead);
            }

            foodIndex = new Random().Next(0, 3);
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }
        private bool IsPartOfSnake()
        {
            return this.snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }

        private void GetNextDirection(Point direction, Point snakeHead)
        {
            this.LeftX = direction.LeftX + snakeHead.LeftX;
            this.TopY = direction.TopY + snakeHead.TopY;
        }
    }
}
