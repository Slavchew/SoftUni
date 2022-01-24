using System;
using System.Reflection;
using System.Text;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type sbType = typeof(Animal);

            var fields = sbType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var fiels = sbType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine(fiels.Name);

            foreach (var field in fields)
            {
                Console.WriteLine(field.IsAssembly);
            }

            Console.WriteLine();
        }
    }
}
