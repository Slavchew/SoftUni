using Snake.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;
        private Snake snake;

        public Engine(IReader reader, IWriter writer, Snake snake)
        {
            this.reader = reader;
            this.writer = writer;
            this.snake = snake;
        }

        public void Run()
        {
            while (true)
            {
                snake.DrawSnake();
            }
        }
    }
}
