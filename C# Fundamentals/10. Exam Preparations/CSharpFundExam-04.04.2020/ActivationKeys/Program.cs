using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var activationKey = Console.ReadLine();

            var input = Console.ReadLine().Split(">>>",StringSplitOptions.RemoveEmptyEntries).ToList();
            while (input[0] != "Generate")
            {
                var command = input[0];
                switch (command)
                {
                    case "Contains":
                        var substring = input[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(input[2]);
                        int endIndex = int.Parse(input[3]);
                        string firstPart = activationKey.Substring(0, startIndex);
                        string secondPart = activationKey.Substring(startIndex, endIndex - startIndex);
                        string thirdPart = activationKey.Substring(endIndex);

                        if (input[1].ToUpper() == "UPPER")
                        {
                            secondPart = secondPart.ToUpper();
                        }
                        else
                        {
                            secondPart = secondPart.ToLower();
                        }
                        activationKey = firstPart + secondPart + thirdPart;
                        Console.WriteLine(activationKey); 
                        break;
                    case "Slice":
                        startIndex = int.Parse(input[1]);
                        endIndex = int.Parse(input[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                }

                input = Console.ReadLine().Split(">>>").ToList();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
