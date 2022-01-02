using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var weak = 0.0;
            var average = 0.0;
            var good = 0.0;
            var excellent = 0.0;
            var sumOfGrades = 0.0;

            for (int i = 0; i < n; i++)
            {
                var grade = double.Parse(Console.ReadLine());
                if (grade < 3)
                {
                    weak++;
                }
                else if (grade >= 3 && grade < 4)
                {
                    average++;
                }
                else if (grade >= 4 && grade < 5)
                {
                    good++;
                }
                else if (grade >= 5)
                {
                    excellent++;
                }
                sumOfGrades += grade;
            }

            var weakPercentage = (weak * 100) / n;
            var averagePercentage = (average * 100) / n;
            var goodPercentage = (good * 100) / n;
            var excellentPercentage = (excellent * 100) / n;

            Console.WriteLine("Top students: {0:f2}%",excellentPercentage);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", goodPercentage);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", averagePercentage);
            Console.WriteLine("Fail: {0:f2}%", weakPercentage);
            Console.WriteLine("Average: {0:f2}",sumOfGrades / n);


        }
    }
}
