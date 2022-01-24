using System;
using System.Linq;

namespace NameLenght
{
    class NameLenght
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split()
                .ToList();


            names.RemoveAll(x => x.Length > n);

            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
