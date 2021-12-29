using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHall
{
    class LearningHall
    {
        static void Main(string[] args)
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            if (3 <= width && width <= lenght && lenght <= 100)
            {
                lenght *= 100;
                width *= 100;
                var rows = (int)lenght / 120;
                var desksOnRow = ((int)width - 100) / 70;
                var places = (rows * desksOnRow) - 3;
                Console.WriteLine(places);
            }
            else
            {
                Console.WriteLine("Имате грешка в началните данни");
            }
        }
    }
}
