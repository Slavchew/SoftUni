using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.TheStoryTelling
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        static void Main(string[] args)
        {
            graph = ReadGraph();
            dependencies = GetPredecessorCount();

            var sorted = TopologicalSorting();

            Console.WriteLine(String.Join(" ", sorted));
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graphResult = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var preStory = parts[0];
                if (preStory.Contains(" ->"))
                {
                    preStory = preStory.Replace(" ->", "");
                }

                if (parts.Length == 1)
                {
                    graphResult[preStory] = new List<string>();
                }
                else
                {
                    var childern = parts[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graphResult[preStory] = new List<string>(childern);
                }
            }

            return graphResult;
        }

        private static Dictionary<string, int> GetPredecessorCount()
        {
            var result = new Dictionary<string, int>();

            foreach (var node in graph.Keys)
            {
                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in graph[node])
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 0);
                    }

                    result[child]++;
                }
            }

            // return result.Reverse().ToDictionary(x => x.Key, x => x.Value);
            return result;
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                // FirstOrDefault
                var nodeToRemove = dependencies.LastOrDefault(x => x.Value == 0);

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
    }
}
