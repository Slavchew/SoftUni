using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                    continue;
                }

                var children = line
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                graph[node] = new List<int>(children);
            }


            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var component = new List<int>();
                DFS(node, component);
                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}
