using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.BreakCycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public string ToStringReversed()
        {
            return $"{this.Second} - {this.First}";
        }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }
    }

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            ProcessInput(n);

            edges = edges
                .OrderBy(x => x.First)
                .ThenBy(x => x.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var blacklisted = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blacklisted.Contains(edge.ToString()))
                    {
                        continue;
                    }

                    removedEdges.Add(edge);
                    blacklisted.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string>();
            visited.Add(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var node = line[0];

                var children = line[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
