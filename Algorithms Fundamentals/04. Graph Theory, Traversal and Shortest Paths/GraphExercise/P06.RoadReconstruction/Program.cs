using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.RoadReconstruction
{
    public class Edge
    {
        public Edge(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; set; }

        public int Second { get; set; }
    }

    internal class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            edges = new List<Edge>();

            ProcessInput(n, e);

            ;
        }

        private static void ProcessInput(int n, int e)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var from = line[0];
                var to = line[1];

                graph[from].Add(to);
                edges.Add(new Edge(from, to));
            }
        }
    }
}
