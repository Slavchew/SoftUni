using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Students
    {
        static void Main(string[] args)
        {
            var startResults = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            var currResult = new List<int>();
            currResult.AddRange(startResults);

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (currResult.Count == 0)
                {
                    break;
                }
                var commnad = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
                var student = commnad[0];
                var grade = commnad[1];

                if (student >= currResult.Count)
                {

                }
                else
                {

                    if (grade < currResult[student])
                    {
                        currResult[student] -= grade;
                    }
                    else if (grade > currResult[student])
                    {
                        currResult[student] += grade;
                    }

                    var temp = startResults[student] / 2;
                    if (currResult[student] < temp)
                    {
                        currResult.RemoveAt(student);
                    }
                }
            }
            if (currResult.Count == 0)
            {
                Console.WriteLine("All studets has been expelled due bad results!");
            }
            else
            {
                Console.WriteLine(string.Join("; ", currResult));
            }
        }
    }
}
