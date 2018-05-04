using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,] { { 2, 2, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

            OutputBoard(board);

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    board = RotateBoard(board);
                    board = ResultantBoard(board);
                    board = RotateBoard(board);
                    board = RotateBoard(board);
                    board = RotateBoard(board);

                    OutputBoard(board);
                }
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    board = RotateBoard(board);
                    board = RotateBoard(board);
                    board = ResultantBoard(board);
                    board = RotateBoard(board);
                    board = RotateBoard(board);

                    OutputBoard(board);
                }
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    board = RotateBoard(board);
                    board = RotateBoard(board);
                    board = RotateBoard(board);
                    board = ResultantBoard(board);
                    board = RotateBoard(board);

                    OutputBoard(board);
                }
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    board = ResultantBoard(board);

                    OutputBoard(board);
                }
            }
        }

        static int[,] ResultantBoard(int[,] board)
        {
            Console.WriteLine();

            board = ShiftBoard(board);

            for (int row = 0; row < 4; row++)
            {
                for (int col = 1; col < 4; col++)
                {
                    int value = board[row, col];
                    int prevNumber = board[row, col - 1];

                    if (value == prevNumber)
                    {
                        board[row, col] = value * 2;
                        board[row, col - 1] = 0;
                    }
                }
            }

            bool possibleMoves = false;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == 0)
                    {
                        possibleMoves = true;
                    }
                }
            }

            board = ShiftBoard(board);

            Random rnd = new Random();

            bool sucessfullyGenerated = false;

            while (!sucessfullyGenerated && possibleMoves)
            {
                int row = rnd.Next(0, 4);
                int col = rnd.Next(0, 4);

                if (board[row, col] == 0)
                {
                    board[row, col] = 2;

                    sucessfullyGenerated = true;
                }
            }

            return board;
        }

        static int[,] ShiftBoard(int[,] board)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (board[row, col] != 0 && col + 1 < 4)
                        {
                            if (board[row, col + 1] == 0)
                            {
                                board[row, col + 1] = board[row, col];
                                board[row, col] = 0;

                                break;
                            }
                        }
                    }
                }
            }

            return board;
        }

        static void OutputBoard(int[,] board)
        {
            Console.Clear();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(" ");

                    if (board[row, col] != 0)
                    {
                        Console.ForegroundColor = (ConsoleColor)(int)Math.Log(board[row, col], 2);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write(board[row, col]);

                    Console.ForegroundColor = ConsoleColor.Gray;

                    for (int i = 0; i < 4 - board[row, col].ToString().Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        static int[,] RotateBoard(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[,] ret = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }

            return ret;
        }
    }
}
