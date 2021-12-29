using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class Sorter
    {
        private ISortingStrategy strategy;
        public Sorter(ISortingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Sort(List<int> collection)
        {
            strategy.Sort(collection);
        }
    }
}
