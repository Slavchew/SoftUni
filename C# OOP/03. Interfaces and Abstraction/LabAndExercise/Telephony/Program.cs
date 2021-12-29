using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                try
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumbers[i]));
                    }
                    else if (phoneNumbers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phoneNumbers[i]));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(sites[i]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
