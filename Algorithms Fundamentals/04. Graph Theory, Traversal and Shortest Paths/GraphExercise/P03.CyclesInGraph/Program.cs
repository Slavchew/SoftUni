using System;
using System.Collections.Generic;

namespace P03.CyclesInGraph
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();

            var line = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            while (line[0] != "End")
            {
                var node = line[0];
                var child = line[1];

                if (!result.ContainsKey(node))
                {
                    result.Add(node, new List<string>());
                }

                if (!result.ContainsKey(child))
                {
                    result.Add(child, new List<string>());
                }

                result[node].Add(child);


                line = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            }

            return result;
        }
    }
}
