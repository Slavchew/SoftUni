using System;
using System.Collections.Generic;

namespace P05.PathsInLabyrinth
{
    internal class Program
    {
        private static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string labLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    lab[row, col] = labLine[col];
                }
            }

            FindAllPaths(lab, 0, 0, new bool[rows, cols], '\0');
        }

        private static void FindAllPaths(char[,] lab, int row, int col, bool[,] visited, char direction)
        {
            
            if (IsOutside(lab, row, col) || 
                IsVisited(visited, row, col) || 
                IsWall(lab, row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsSolution(lab, row, col))
            {
                Console.WriteLine(string.Join("", path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            visited[row, col] = true;

            FindAllPaths(lab, row - 1, col, visited, 'U');
            FindAllPaths(lab, row + 1, col, visited, 'D');
            FindAllPaths(lab, row, col - 1, visited, 'L');
            FindAllPaths(lab, row, col + 1, visited, 'R');

            path.RemoveAt(path.Count - 1);
            visited[row, col] = false;
            

            /*
            if (IsSolution(lab, row, col))
            {
                Console.WriteLine(path);
                return; 
            }


            visited[row, col] = true;

            if (IsSafe(lab, row + 1, col, visited))
            {
                FindAllPaths(lab, row + 1, col, visited, path + "D");
            }
            if (IsSafe(lab, row - 1, col, visited))
            {
                FindAllPaths(lab, row - 1, col, visited, path + "U");
            }
            if (IsSafe(lab, row, col + 1, visited))
            {
                FindAllPaths(lab, row, col + 1, visited, path + "R");
            }
            if (IsSafe(lab, row, col - 1, visited))
            {
                FindAllPaths(lab, row, col - 1, visited, path + "L");
            }
            */

        }

        private static bool IsSafe(char[,] lab, int row, int col, bool[,] visited)
        {
            if (IsOutside(lab, row, col))
            {
                return false;
            }
            if (lab[row, col] == '*' || visited[row, col])
            {
                return false;
            }

            return true;
        }

        private static bool IsSolution(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsWall(char[,] lab, int row, int col)
        {
            return lab[row, col] == '*'; 
        }

        private static bool IsVisited(bool[,] visited, int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsOutside(char[,] lab, int row, int col)
        {
            return row < 0 ||
                row >= lab.GetLength(0) ||
                col < 0 ||
                col >= lab.GetLength(1);
        }
    }
}
