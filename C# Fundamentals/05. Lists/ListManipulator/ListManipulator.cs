using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulator
{
    class ListManipulator
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> commands = Console.ReadLine().Split(' ').ToList();
            while (commands[0] != "print")
            {
                if (commands[0] == "add")
                {
                    var index = int.Parse(commands[1]);
                    var num = int.Parse(commands[2]);

                    nums.Insert(index, num);
                }
                else if (commands[0] == "addMany")
                {
                    var index = int.Parse(commands[1]);
                    var n = commands.Count - 2;
                    List<int> addednums = new List<int>();
                    for (int i = 0; i < n; i++)
                    {
                        addednums.Add(int.Parse(commands[i + 2]));
                    }
                    nums.InsertRange(index , addednums);
                }
                else if (commands[0] == "contains")
                {
                    var num = int.Parse(commands[1]);
                    bool contain = false;
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] == num)
                        {
                            Console.WriteLine(i);
                            contain = true;
                            break;
                        }
                    }
                    if (!contain)
                    {
                        Console.WriteLine(-1);
                    }
                }
                else if (commands[0] == "remove")
                {
                    var index = int.Parse(commands[1]);
                    nums.RemoveAt(index);
                }
                else if (commands[0] == "shift")
                {
                    int rotate = int.Parse(commands[1]);
                    for (int i = 0; i < rotate; i++)
                    {
                        int firstItem = nums[0];
                        nums.RemoveAt(0);
                        nums.Insert(nums.Count, firstItem);
                    }
                }
                else if (commands[0] == "sumPairs")
                {
                    for (int i = 1; i < nums.Count; i++)
                    {
                        var sum = nums[i - 1] + nums[i];
                        nums.RemoveRange(i - 1, 2);
                        nums.Insert(i - 1, sum);
                    }
                }
                commands = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
