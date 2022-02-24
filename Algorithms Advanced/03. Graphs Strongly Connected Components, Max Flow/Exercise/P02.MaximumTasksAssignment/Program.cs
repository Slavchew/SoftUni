using System;
using System.Collections.Generic;

namespace P02.MaximumTasksAssignment
{
    public class Program
    {
        private static int[,] graph;
        private static int[] parents;
        public static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            graph = ReadGraph(people, tasks);

            var nodes = graph.GetLength(0);

            parents = new int[nodes];
            Array.Fill(parents, -1);

            var start = 0;
            var target = nodes - 1;

            while (BFS(start, target))
            {
                var node = target;
                while (node != start)
                {
                    var parent = parents[node];

                    graph[parent, node] = 0;
                    graph[node, parent] = 1;

                    node = parent;
                }
            }

            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (graph[task, person] > 0)
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - people}");
                        break;
                    }
                }
            }
        }

        private static bool BFS(int start, int target)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

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
                        parents[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int people, int tasks)
        {
            var nodes = people + tasks + 2;

            var result = new int[nodes, nodes];

            var start = 0;
            var target = nodes - 1;

            for (int task = people + 1; task < nodes - 1; task++)
            {
                result[task, target] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                var personTasks = Console.ReadLine();

                for (int task = 0; task < personTasks.Length; task++)
                {
                    if (personTasks[task] == 'Y')
                    {
                        result[person, people + 1 + task] = 1;
                    }
                }

                result[start, person] = 1;
            }

            return result;
        }
    }
}
