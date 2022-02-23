using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P05.CableNetwork
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
        private static List<Edge>[] graph;
        private static HashSet<int> spanningTree;
        public static void Main(string[] args)
        {
            var budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            spanningTree = new HashSet<int>();
            graph = ReadGraph(nodes, edgesCount);

            var usedBudget = Prim(budget);
            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int Prim(int budget)
        {
            var usedBudget = 0;

            var queue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            foreach (var node in spanningTree)
            {
                queue.AddMany(graph[node]);
            }

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();
                var nonTreeNode = GetNonTreeNode(edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                if (edge.Weight > budget)
                {
                    break;
                }

                usedBudget += edge.Weight;
                budget -= edge.Weight;

                spanningTree.Add(nonTreeNode);

                queue.AddMany(graph[nonTreeNode]);
            }

            return usedBudget;
        }

        private static int GetNonTreeNode(Edge edge)
        {
            if (spanningTree.Contains(edge.First) && !spanningTree.Contains(edge.Second))
            {
                return edge.Second;
            }
            else if (!spanningTree.Contains(edge.First) && spanningTree.Contains(edge.Second))
            {
                return edge.First;
            }

            return -1;
        }

        private static List<Edge>[] ReadGraph(int nodes, int edgesCount)
        {
            var result = new List<Edge>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split(" ");

                var first = int.Parse(edgeData[0]);
                var second = int.Parse(edgeData[1]);
                var weight = int.Parse(edgeData[2]);

                if (edgeData.Length == 4)
                {
                    spanningTree.Add(first);
                    spanningTree.Add(second);
                }

                var edge = new Edge()
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
