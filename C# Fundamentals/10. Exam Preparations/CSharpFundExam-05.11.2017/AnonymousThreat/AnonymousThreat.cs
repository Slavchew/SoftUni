using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();
            var commands = Console.ReadLine().Split(' ');
            while (commands[0] != "3:1")
            {
                var command = commands[0];
                if (command == "merge")
                {
                    var startIndex = int.Parse(commands[1]);
                    var endIndex = int.Parse(commands[2]);
                    if (startIndex < 0)
                        startIndex = 0;
                    if (endIndex > input.Count - 1)
                        endIndex = input.Count - 1;

                    for (int i = startIndex; i < endIndex; endIndex--)
                    {
                        input[i] = input[i] + input[i + 1];
                        input.RemoveAt(i + 1);
                    }
                }
                else if (command == "divide")
                {
                    var index = int.Parse(commands[1]);
                    var partitions = int.Parse(commands[2]);
                    string currentString = input[index];
                    var lenghtOfPartitions = currentString.Length / partitions;
                    var additions = new List<string>(partitions);
                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string currentAdition = currentString.Substring(0, lenghtOfPartitions);
                        additions.Add(currentAdition);
                        currentString = currentString.Substring(lenghtOfPartitions);
                    }
                    additions.Add(currentString);
                    input.RemoveAt(index);
                    input.InsertRange(index, additions);
                }

                commands = Console.ReadLine().Split(' ');
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
