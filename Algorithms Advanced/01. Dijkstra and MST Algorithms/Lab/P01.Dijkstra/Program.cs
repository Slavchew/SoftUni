using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P01.Dijkstra
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
        private static Dictionary<int, List<Edge>> graph;
        public static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());
            graph = ReadGraph(e);

            ;

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var maxNode = graph.Keys.Max();

            var distances = new int[maxNode + 1];
            Array.Fill(distances, int.MaxValue);

            distances[start] = 0;

            var prev = new int[maxNode + 1];
            prev[start] = -1;

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distances[f] - distances[s]));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var minNode = queue.RemoveFirst();

                if (minNode == end)
                {
                    break;
                }

                var children = graph[minNode];
                foreach (var child in children)
                {
                    var childNode = child.First == minNode 
                        ? child.Second 
                        : child.First;

                    if (distances[childNode] == int.MaxValue)
                    {
                        queue.Add(childNode);
                    }

                    var newDistance = child.Weight + distances[minNode];
                    if (newDistance < distances[childNode])
                    {
                        distances[childNode] = newDistance;
                        prev[childNode] = minNode;

                        queue = new OrderedBag<int>(
                            queue, 
                            Comparer<int>.Create((f, s) => distances[f] - distances[s]));
                    }
                }
            }

            if (distances[end] == int.MaxValue)
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(distances[end]);

                var path = new Stack<int>();
                var node = end;
                while (node != -1)
                {
                    path.Push(node);
                    node = prev[node];
                }

                Console.WriteLine(String.Join(" ", path));
            }
        }
        private static Dictionary<int, List<Edge>> ReadGraph(int e)
        {
            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                if (!result.ContainsKey(firstNode))
                {
                    result.Add(firstNode, new List<Edge>());
                }

                if (!result.ContainsKey(secondNode))
                {
                    result.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge(firstNode, secondNode, weight);

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
