using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.CheapTownTour
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second} {this.Weight}";
        }
    }

    public class Program
    {
        private static List<Edge> edges;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadGraph(edgesCount);

            var sortedEdges = edges
               .OrderBy(x => x.Weight)
               .ToList();

            var root = new int[nodesCount];
            for (int node = 0; node < nodesCount; node++)
            {
                root[node] = node;
            }

            var totalCost = 0;
            foreach (var edge in sortedEdges)
            {
                var firstRoot = GetRoot(edge.First, root);
                var secondRoot = GetRoot(edge.Second, root);

                if (firstRoot != secondRoot)
                {
                    root[firstRoot] = secondRoot;
                    totalCost += edge.Weight;
                }
            }

            Console.WriteLine(totalCost);
        }

        private static int GetRoot(int node, int[] root)
        {
            while (node != root[node])
            {
                node = root[node];
            }

            return node;
        }

        private static List<Edge> ReadGraph(int edgesCount)
        {
            var result = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                result.Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight
                });
            }

            return result;
        }
    }
}
