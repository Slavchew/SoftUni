using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesArea
{
    class ShapesArea
    {
        static void Main(string[] args)
        {
            var shape = Console.ReadLine().ToLower();
            if (shape == "square")
            {
                var a = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * a,3));
            }
            else if (shape == "rectangle")
            {
                var b = double.Parse(Console.ReadLine());
                var b1 = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(b * b1,3));
            }
            else if (shape == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(Math.PI * r * r,3));
            }
            else if (shape == "triangle")
            {
                var c = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((c*h /2) ,2));
            }
            else
            {
                Console.WriteLine("Грешна фигура");
            }
        }
    }
}
