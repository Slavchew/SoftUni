using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.DecryptTheMessage
{
    class DecryptTheMessage
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                message += (char)(key + letter);
            }
            Console.WriteLine(message);
        }
    }
}
