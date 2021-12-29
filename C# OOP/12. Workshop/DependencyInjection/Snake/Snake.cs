using Snake.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        private IWriter writer;

        public Snake(IWriter writer)
        {
            this.writer = writer;
        }

        public void DrawSnake()
        {
            writer.Write("Snake");
        }
    }
}
