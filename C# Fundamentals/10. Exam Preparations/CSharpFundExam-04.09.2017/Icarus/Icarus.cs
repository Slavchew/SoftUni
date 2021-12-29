using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus
{
    class Icarus
    {
        static void Main(string[] args)
        {
            var plane = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int indexIcarus = int.Parse(Console.ReadLine());
            var initialDamage = 1;

            var commands = Console.ReadLine().Split(' ');
            while (commands[0] != "Supernova")
            {
                var position = commands[0];
                var len = int.Parse(commands[1]);

                if (position == "left")
                {
                    for (int i = 0; i < len; i++)
                    {
                        indexIcarus--;
                        if (indexIcarus < 0)
                        {
                            indexIcarus = plane.Count() - 1;
                            initialDamage++;
                        }
                        plane[indexIcarus] -= initialDamage;
                    }
                }
                else if (position == "right")
                {
                    for (int i = 0; i < len; i++)
                    {
                        indexIcarus++;
                        if (indexIcarus > plane.Count() - 1)
                        {
                            indexIcarus = 0;
                            initialDamage++;
                        }

                        plane[indexIcarus] -= initialDamage;
                    }
                }

                commands = Console.ReadLine().Split(' ');
            }

            Console.WriteLine(string.Join(" ",plane));
        }
    }
}
