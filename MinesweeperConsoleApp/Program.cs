using System;

namespace MinesweeperConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello, welcome to Minesweeper\n");

            // Generate and print first board
            Console.WriteLine("Here is the answer key for the first board");
            var firstBoard = new MinesweeperBoard(10, 10, 15);
            firstBoard.GenerateBoard();
            firstBoard.PrintBoard();

            Console.WriteLine("\nHere is the answer key for the second board");
            // ⬇️ Updated to 15 x 15 instead of 15 x 9
            var secondBoard = new MinesweeperBoard(15, 15, 30);
            secondBoard.GenerateBoard();
            secondBoard.PrintBoard();

            Console.ResetColor();
        }
    }

    public class MinesweeperBoard
    {
        private int Rows;
        private int Columns;
        private int MineCount;
        private char[,] Board;

        public MinesweeperBoard(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
            Board = new char[Rows, Columns];
        }

        public void GenerateBoard()
        {
            // Initialize empty board
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++)
                    Board[r, c] = '.';

            // Randomly place mines
            var rand = new Random();
            int placed = 0;
            while (placed < MineCount)
            {
                int r = rand.Next(Rows);
                int c = rand.Next(Columns);
                if (Board[r, c] != 'B')
                {
                    Board[r, c] = 'B';
                    placed++;
                }
            }

            // Fill in numbers
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Board[r, c] == 'B') continue;
                    int count = CountAdjacentMines(r, c);
                    Board[r, c] = count == 0 ? '.' : count.ToString()[0];
                }
            }
        }

        private int CountAdjacentMines(int row, int col)
        {
            int count = 0;
            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (r == 0 && c == 0) continue;
                    int nr = row + r, nc = col + c;
                    if (nr >= 0 && nr < Rows && nc >= 0 && nc < Columns)
                    {
                        if (Board[nr, nc] == 'B') count++;
                    }
                }
            }
            return count;
        }

        public void PrintBoard()
        {
            Console.Write("    ");
            for (int c = 0; c < Columns; c++)
                Console.Write($"{c,2} ");
            Console.WriteLine();

            Console.Write("    ");
            for (int c = 0; c < Columns; c++)
                Console.Write("---");
            Console.WriteLine();

            for (int r = 0; r < Rows; r++)
            {
                Console.Write($"{r,2} |");
                for (int c = 0; c < Columns; c++)
                {
                    char cell = Board[r, c];
                    SetColor(cell);
                    Console.Write($" {cell} ");
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

            Console.Write("    ");
            for (int c = 0; c < Columns; c++)
                Console.Write("---");
            Console.WriteLine();
        }

        private void SetColor(char cell)
        {
            switch (cell)
            {
                case 'B': Console.ForegroundColor = ConsoleColor.Red; break;
                case '1': Console.ForegroundColor = ConsoleColor.Cyan; break;
                case '2': Console.ForegroundColor = ConsoleColor.Green; break;
                case '3': Console.ForegroundColor = ConsoleColor.Magenta; break;
                case '4': Console.ForegroundColor = ConsoleColor.Yellow; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
        }
    }
}
