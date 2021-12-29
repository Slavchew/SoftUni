using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterList
{
    class EnterList
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //List<int> list = new List<int>();
            //for (int i = 0; i < n; i++)
            //{
            //    list.Add(int.Parse(Console.ReadLine()));
            //}

            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int index = 0; index < nums.Count; index++)
            {
                Console.WriteLine("nums[{0}] = {1}", index, nums[index]);
            }



        }
    }
}
