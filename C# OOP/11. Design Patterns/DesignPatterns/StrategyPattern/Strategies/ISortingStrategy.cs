using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Strategies
{
    interface ISortingStrategy
    {
        void Sort(List<int> collection);
    }
}
