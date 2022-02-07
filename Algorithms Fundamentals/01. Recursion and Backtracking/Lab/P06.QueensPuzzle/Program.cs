using System;
using System.Collections.Generic;

namespace P06.QueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            var board = new bool[8, 8];


            // int solutions = GetQueens(board, 0);
            // Console.WriteLine(solutions);

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (!IsAttacked(row, col))
                {
                    Mark(board, row, col);

                    PutQueens(board, row + 1);

                    UnMark(board, row, col);
                }
            }
        }

        private static void UnMark(bool[,] board, int row, int col)
        {
            board[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(row - col);
            attackedRightDiagonals.Remove(row + col);
        }

        private static void Mark(bool[,] board, int row, int col)
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(row - col);
            attackedRightDiagonals.Add(row + col);
        }

        private static bool IsAttacked(int row, int col)
        {
            return attackedRows.Contains(row) || 
                   attackedCols.Contains(col) || 
                   attackedLeftDiagonals.Contains(row - col) || 
                   attackedRightDiagonals.Contains(row + col);
        }

        private static int GetQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row, col] = true;
                    foundQueens += GetQueens(board, row + 1);
                    board[row, col] = false;
                }
            }

            return foundQueens;
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == true)
                    {
                        Console.Write("* ");
                    }
                    if (board[row, col] == false)
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool IsSafe(bool[,] board, int row, int col)
        {
            for (int i = 1; i <= board.GetLength(0); i++)
            {
                if (row - i >= 0 && board[row - i, col] == true)
                {
                    return false;
                }
                if (col - i >= 0 && board[row, col - i] == true)
                {
                    return false;
                }
                if (row + i < board.GetLength(0) && board[row + i, col] == true)
                {
                    return false;
                }
                if (col + i < board.GetLength(1) && board[row, col + 1] == true)
                {
                    return false;
                }

                if (col + i < board.GetLength(1) &&
                    row + i < board.GetLength(0) &&
                    board[row + i, col + i] == true)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row - i >= 0 &&
                    board[row - i, col - i] == true)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row + i < board.GetLength(0) &&
                    board[row + i, col - i] == true)
                {
                    return false;
                }
                if (col + i < board.GetLength(1) &&
                    row - i >= 0 &&
                    board[row - i, col + i] == true)
                {
                    return false;
                }

            }

            return true;
        }
    }
}
