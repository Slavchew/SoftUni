using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            dependencies = GetPredecessorCount();

            var sorted = TopologicalSorting();

            if (sorted == null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0);

                if (string.IsNullOrEmpty(nodeToRemove.Key))
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = graph[node];

                sorted.Add(node);

                foreach (var child in children)
                {
                    dependencies[child]--;
                }

                dependencies.Remove(node);
            }

            if (dependencies.Count > 0)
            {
                return null;
            }

            return sorted;
        }

        private static Dictionary<string, int> GetPredecessorCount()
        {
            var result = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                var key = node.Key;
                var children = node.Value;

                if (!result.ContainsKey(key))
                {
                    result.Add(key, 0);
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 0);
                    }

                    result[child]++;
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graphResult = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);


                var node = line[0];

                if (node.Contains(" ->"))
                {
                    node = node.Replace(" ->", "");
                }

                if (line.Length == 1)
                {
                    graphResult[node] = new List<string>();
                }
                else
                {
                    var childern = line[1]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graphResult[node] = new List<string>(childern);
                }
            }

            return graphResult;
        }
    }
}
