using System;

namespace StatisticalSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            People people = new People();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                var name = input[0];
                var age = int.Parse(input[1]);

                people.AddMember(new Person(name, age));
            }
            people.Over30();
        }
    }
}
