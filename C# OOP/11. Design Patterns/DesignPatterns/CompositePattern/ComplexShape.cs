using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    class ComplexShape : IDrawable
    {
        private List<IDrawable> shapes = new List<IDrawable>();

        public string Name { get; set; }

        public ComplexShape(string name)
        {
            Name = name;
        }

        public void AddChild(IDrawable child)
        {
            shapes.Add(child);
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
            foreach (var shape in shapes)
            {
                shape.Draw(level + 3);
            }
        }
    }
}
