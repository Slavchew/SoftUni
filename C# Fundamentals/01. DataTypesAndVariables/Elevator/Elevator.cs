using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            int places = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)peoples / places);
            Console.WriteLine(courses);
        }
    }
}
