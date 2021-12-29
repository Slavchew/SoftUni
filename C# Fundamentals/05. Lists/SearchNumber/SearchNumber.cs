using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNumber
{
    class SearchNumber
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> commands = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = new List<int>();
            var length = commands[0];
            var del = commands[1];
            var num = commands[2];

            for (int i = 0; i < length; i++)
            {
                result.Add(nums[i]);
            }

            result.RemoveRange(0, del);
            if (result.Contains(num))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
