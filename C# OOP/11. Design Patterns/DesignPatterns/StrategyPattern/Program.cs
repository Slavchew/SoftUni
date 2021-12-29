using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string sotyType = Console.ReadLine();

            var strategyType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ISortingStrategy).IsAssignableFrom(t) &&
                t.Name.StartsWith(sotyType))
                .FirstOrDefault();


            ISortingStrategy strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);

            Sorter sorter = new Sorter(strategy);

            sorter.Sort(new List<int> { 1, 2, 3, 8, 4, 6 });
        }
    }
}
