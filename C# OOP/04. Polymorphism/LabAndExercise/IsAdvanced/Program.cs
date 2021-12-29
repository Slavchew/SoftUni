using System;

namespace IsAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 10;

            if (max is var maxVar)
            {
                Console.WriteLine(maxVar);
            }  
        }
    }
}
