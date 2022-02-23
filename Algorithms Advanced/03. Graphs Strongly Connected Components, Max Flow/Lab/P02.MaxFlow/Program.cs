using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.MaxFlow
{
    internal class Program
    {
        private static int[,] graph;
        private static int[] parents;
        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes);

            var source = int.Parse(Console.ReadLine());
            var target = int.Parse(Console.ReadLine());

            parents = new int[nodes];
            Array.Fill(parents, -1);

            var maxFlow = 0;

            while (BFS(source, target))
            {
                var currentFlow = GetCurrentFlow(source, target);
                maxFlow += currentFlow;

                ApplyCurrentFlow(source, target, currentFlow);
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyCurrentFlow(int source, int target, int currentFlow)
        {
            var node = target;
            while (node != source)
            {
                var parent = parents[node];

                graph[parent, node] -= currentFlow;

                node = parent;
            }
        }

        private static int GetCurrentFlow(int source, int target)
        {
            var node = target;
            var minFlow = int.MaxValue;
            while (node != source)
            {
                var parent = parents[node];

                var flow = graph[parent, node];
                if (flow < minFlow)
                {
                    minFlow = flow;
                }

                node = parent;
            }

            return minFlow;
        }

        private static bool BFS(int source, int target)
        {
            var queue = new Queue<int>();
            var visited = new bool[graph.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == target)
                {
                    return true;
                }

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        parents[child] = node;
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int nodes)
        {
            var result = new int[nodes, nodes];

            for (int node = 0; node < nodes; node++)
            {
                var capacities = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    var capacity = capacities[child];

                    result[node, child] = capacity;
                }
            }

            return result;
        }
    }
}
