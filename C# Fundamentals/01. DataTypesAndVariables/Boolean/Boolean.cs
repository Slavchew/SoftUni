using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean
{
    class Boolean
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool variable = Convert.ToBoolean(input);
            if (variable == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
