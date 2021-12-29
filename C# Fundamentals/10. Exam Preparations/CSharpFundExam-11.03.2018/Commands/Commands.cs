using System;
using System.Linq;

namespace Commands
{
    class Commands
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(" ").Select(long.Parse).ToList();

            var command = Console.ReadLine().Split(" ");
            while (command[0] != "print")
            {
                if (command[0] == "push")
                {
                    var element = long.Parse(command[1]);
                    list.Add(element);
                }
                else if (command[0] == "pop")
                {
                    var element = list.Last();
                    Console.WriteLine(element);
                    list.RemoveAt(list.Count - 1);
                }
                else if (command[0] == "shift")
                {
                    var firstElement = list.First();
                    var lastElement = list.Last();

                    var temp = firstElement;
                    list[list.Count - 1] = temp;
                    list[0] = lastElement;
                }
                else if (command[0] == "addMany")
                {
                    var position = int.Parse(command[1]);
                    var range = command.Skip(2).Select(long.Parse).ToList();
                    if (position < list.Count)
                    {
                        list.InsertRange(position, range);
                    }
                }
                else if (command[0] == "remove")
                {
                    var position = int.Parse(command[1]);
                    if (position < list.Count)
                    {
                        list.RemoveAt(position);
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            list.Reverse();
            Console.WriteLine(string.Join(", ",list));
        }
    }
}
