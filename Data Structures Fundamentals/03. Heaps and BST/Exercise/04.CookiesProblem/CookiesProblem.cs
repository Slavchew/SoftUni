using _03.MinHeap;
using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            // return SolutionWithOrderedBag(k, cookies);
            return SolutionWithMinHeap(k, cookies);
        }

        private static int SolutionWithOrderedBag(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);

            int steps = 0;

            var smallestElement = bag.GetFirst();
            while (smallestElement < k && bag.Count >= 2)
            {
                var smallestCookie = bag.RemoveFirst();
                var secondSmallestCookie = bag.RemoveFirst();

                steps++;
                bag.Add(smallestCookie + (2 * secondSmallestCookie));

                smallestElement = bag.GetFirst();
            }

            return smallestElement >= k ? steps : -1;
        }

        private static int SolutionWithMinHeap(int k, int[] cookies)
        {
            var bag = new MinHeap<int>();

            cookies.ToList().ForEach(x => bag.Add(x));

            int steps = 0;

            var smallestElement = bag.Peek();
            while (smallestElement < k && bag.Size >= 2)
            {
                var smallestCookie = bag.Dequeue();
                var secondSmallestCookie = bag.Dequeue();

                steps++;
                bag.Add(smallestCookie + (2 * secondSmallestCookie));

                smallestElement = bag.Peek();
            }

            return smallestElement >= k ? steps : -1;
        }
    }
}
