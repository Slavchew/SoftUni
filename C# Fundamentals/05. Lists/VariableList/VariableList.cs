using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableList
{
    class VariableList
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            while (true)
            {
                List<string> commands = Console.ReadLine().Split(' ').ToList();
                if (commands[0] == "Odd")
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] % 2 == 0)
                        {
                            nums.RemoveAt(i);
                            i--;
                        }
                    }
                    Console.WriteLine(string.Join(" ",nums));
                    break;
                }
                else if (commands[0] == "Even")
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] % 2 == 1)
                        {
                            nums.RemoveAt(i);
                            i--;
                        }
                    }
                    Console.WriteLine(string.Join(" ", nums));
                    break;
                }
                else
                {
                    if (commands[0] == "Delete") 
                    {
                        var num = int.Parse(commands[1]);
                        while (nums.Contains(num))
                        {
                            nums.Remove(num);
                        }
                    }
                    else if (commands[0] == "Insert")
                    {
                        var num = int.Parse(commands[1]);
                        var index = int.Parse(commands[2]);
                        nums.Insert(index, num);
                    }
                }
            }
        }
    }
}
