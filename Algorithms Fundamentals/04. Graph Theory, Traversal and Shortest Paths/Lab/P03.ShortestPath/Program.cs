using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShortestPath
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = ReadGraph(n, e);
            visited = new bool[graph.Length];
            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            BFS(startNode, endNode);
        }

        private static void BFS(int source, int destination)
        {
            if (visited[source])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(source);

            visited[source] = true;


            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructPath(destination);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));

                    return;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int destination)
        {
            var path = new Stack<int>();
            var index = destination;

            while (index != -1)
            {
                path.Push(index);
                index = parents[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int n, int e)
        {
            var graphResult = new List<int>[n + 1];

            for (int i = 0; i < graphResult.Length; i++)
            {
                graphResult[i] = new List<int>();
            }

            for (int i = 1; i <= e; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = line[0];
                var to = line[1];

                graphResult[from].Add(to);
            }

            return graphResult;
        }
    }
}
