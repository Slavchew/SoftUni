using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ConnectedAreasInMatrix
{
    public class Area
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
    }

    internal class Program
    {
        private static int rows;
        private static int cols;

        private static char[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            matrix = MakeMatrix(rows, cols);
            visited = new bool[rows, cols];


            var areas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        continue;
                    }

                    if (visited[row, col])
                    {
                        continue;
                    }

                    var areaSize = GetArea(row, col);

                    var area = new Area { Row = row, Col = col, Size = areaSize };

                    areas.Add(area);
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            int count = 1;
            foreach (var area in areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col))
            {
                Console.WriteLine($"Area #{count} at ({area.Row}, {area.Col}), size: {area.Size}");
                count++;
            }

        }

        private static int GetArea(int row, int col)
        {
            if (IsOutside(row, col))
            {
                return 0;
            }

            if (visited[row, col])
            {
                return 0;
            }

            if (matrix[row, col] == '*')
            {
                return 0;
            }

            visited[row, col] = true;

            return 1 + GetArea(row - 1, col) + GetArea(row + 1, col) + 
                   GetArea(row, col - 1) + GetArea(row, col + 1);
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 ||
                col < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1);
        }

        private static char[,] MakeMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var rowElements = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            return matrix;
        }
    }
}
