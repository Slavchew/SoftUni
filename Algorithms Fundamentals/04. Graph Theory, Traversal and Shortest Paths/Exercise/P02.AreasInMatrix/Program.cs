using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AreasInMatrix
{
    public class Node
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];

            var areas = new SortedDictionary<char, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    DFS(row, col);

                    var key = matrix[row, col];
                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Sum(x => x.Value)}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();

            if (IsInside(row - 1, col) && 
                IsChild(row, col, row - 1, col) && 
                !IsVisited(row - 1, col))
            {
                children.Add(new Node { Row = row - 1, Col = col });
            }

            if (IsInside(row + 1, col) &&
                IsChild(row, col, row + 1, col) &&
                !IsVisited(row + 1, col))
            {
                children.Add(new Node { Row = row + 1, Col = col });
            }

            if (IsInside(row, col - 1) &&
                IsChild(row, col, row, col - 1) &&
                !IsVisited(row, col - 1))
            {
                children.Add(new Node { Row = row, Col = col - 1 });
            }

            if (IsInside(row, col + 1) &&
                IsChild(row, col, row, col + 1) &&
                !IsVisited(row, col + 1))
            {
                children.Add(new Node { Row = row, Col = col + 1 });
            }


            return children;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol)
        {
            return matrix[parentRow, parentCol] == matrix[childRow, childCol];
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 
                && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < elements.Length; col++)
                {
                    result[row, col] = elements[col];
                }
            }

            return result;
        }
    }
}
