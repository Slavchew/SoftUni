using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.StronglyConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reversedGraph;
        private static Stack<int> sorted;

        public static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            (graph, reversedGraph) = ReadGraph(nodesCount, linesCount);

            sorted = TopologicalSorting();
            var visited = new bool[nodesCount];

            Console.WriteLine("Strongly Connected Components:");
            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                var component = new Stack<int>();

                DFS(reversedGraph, node, component, visited);

                Console.WriteLine($"{{{string.Join(", ", component)}}}");
            }
        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(graph, node, result, visited);
            }

            return result;
        }

        private static void DFS(List<int>[] source, int node, Stack<int> stack, bool[] visited)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in source[node])
            {
                DFS(source, child, stack, visited);
            }

            stack.Push(node);
        }

        private static (List<int>[] original, List<int>[] reversed) ReadGraph(int nodesCount, int linesCount)
        {
            var result = new List<int>[nodesCount];
            var reversed = new List<int>[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                result[node] = new List<int>();
                reversed[node] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                var data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var node = data[0];

                for (int j = 1; j < data.Length; j++)
                {
                    var child = data[j];
                    result[node].Add(child);
                    reversed[child].Add(node);
                }
            }

            return (result, reversed);
        }
    }
}
