using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    class SimpleShape : IDrawable
    {
        public SimpleShape(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void AddChild(IDrawable child)
        {
            throw new ArgumentException("Simple shapes cannot have children");
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
        }
    }
}
