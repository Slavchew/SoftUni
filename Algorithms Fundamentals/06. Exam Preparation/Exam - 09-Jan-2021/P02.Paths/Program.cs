using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Paths
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            for (int i = 0; i < n - 1; i++)
            {
                int source = i;
                int destination = n - 1;

                PrintAllPaths(source, destination, n);
            }
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    result[i] = new List<int>();
                    continue;
                }

                var children = line
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                result[i] = new List<int>(children);
            }

            return result;
        }
        private static void PrintAllPaths(int source, int destination, int vertices)
        {
            bool[] visited = new bool[vertices];
            List<int> pathList = new List<int>();

            pathList.Add(source);

            PrintAllPathsUtil(source, destination, visited, pathList);
        }

        private static void PrintAllPathsUtil(int source, int destination, bool[] visited, List<int> localPathList)
        {

            if (source.Equals(destination))
            {
                Console.WriteLine(string.Join(" ", localPathList));
                return;
            }

            visited[source] = true;

            foreach (int child in graph[source])
            {
                if (!visited[child])
                {
                    localPathList.Add(child);
                    PrintAllPathsUtil(child, destination, visited, localPathList);
                    localPathList.Remove(child);
                }
            }

            visited[source] = false;
        }
    }
}
