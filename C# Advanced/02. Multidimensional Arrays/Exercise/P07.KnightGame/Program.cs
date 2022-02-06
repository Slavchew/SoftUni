using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, int>> knightMoves = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(-2, +1),
                new Tuple<int, int>(-1, +2),
                new Tuple<int, int>(+1, +2),
                new Tuple<int, int>(+2, +1),
                new Tuple<int, int>(+2, -1),
                new Tuple<int, int>(+1, -2),
                new Tuple<int, int>(-1, -2),
                new Tuple<int, int>(-2, -1),
            };

            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowElements = Console.ReadLine().Trim();

                for (int col = 0; col < rowElements.Length; col++)
                {
                    board[row, col] = rowElements[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = int.MinValue;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (board[row, col] != 'K')
                            continue;


                        for (int i = 0; i < knightMoves.Count; i++)
                        {
                            int rowMove = knightMoves[i].Item1;
                            int colMove = knightMoves[i].Item2;

                            if (IsInside(board, row + rowMove, col + colMove) &&
                                board[row + rowMove, col + colMove] == 'K')
                            {
                                currentAttacks++;
                            }
                        }


                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    break;
                }
                else
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1);
        }
    }
}
