using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Kruskal
{
    public class Edge
    {
        public Edge(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge> edges;
        static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());

            edges = ReadEdges(e);

            var sortedEdges = edges
                .OrderBy(x => x.Weight)
                .ToList();

            var nodes = edges.Select(x => x.First)
                .Union(edges.Select(x => x.Second))
                .ToHashSet();

            var parents = Enumerable.Repeat(-1, nodes.Max() + 1).ToArray();

            foreach (var node in nodes)
            {
                parents[node] = node;
            }

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = GetRoot(parents, edge.First);
                var secondNodeRoot = GetRoot(parents, edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");
                parents[firstNodeRoot] = secondNodeRoot;
            }
        }

        private static int GetRoot(int[] parents, int node)
        {
            while (node != parents[node])
            {
                node = parents[node];
            }

            return node;
        }

        private static List<Edge> ReadEdges(int e)
        {
            var result = new List<Edge>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                result.Add(new Edge(first, second, weight));
            }

            return result;
        }
    }
}
