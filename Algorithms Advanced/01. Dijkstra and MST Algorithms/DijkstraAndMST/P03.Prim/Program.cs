using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P03.Prim
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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static HashSet<int> forest;

        static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());

            edgesByNode = ReadGraph(e);
            forest = new HashSet<int>();

            foreach (var node in edgesByNode.Keys)
            {
                if (!forest.Contains(node))
                {
                    Prim(node);
                }
            }
        }

        private static void Prim(int node)
        {
            forest.Add(node);

            var queue = new OrderedBag<Edge>(
                edgesByNode[node], 
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(edge.First, edge.Second);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");

                forest.Add(nonTreeNode);

                queue.AddMany(edgesByNode[nonTreeNode]);
            }
        }

        private static int GetNonTreeNode(int first, int second)
        {
            if (forest.Contains(first) && !forest.Contains(second))
            {
                return second;
            }
            else if (!forest.Contains(first) && forest.Contains(second))
            {
                return first;
            }

            return -1;
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int e)
        {
            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                if (!result.ContainsKey(first))
                {
                    result.Add(first, new List<Edge>());
                }

                if (!result.ContainsKey(second))
                {
                    result.Add(second, new List<Edge>());
                }

                var edge = new Edge(first, second, weight);

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
