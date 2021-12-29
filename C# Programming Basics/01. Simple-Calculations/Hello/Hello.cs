using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Hello
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи име: ");
            var name = Console.ReadLine();
            Console.WriteLine("Hello, {0}! ",name);
        }
    }
}
