using MinesweeperClassLibrary.Models;
using System;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardLogic
    {
        private readonly Random _rand = new();

        public void SetupBombs(BoardModel board)
        {
            int bombCount = (int)(board.Size * board.Size * board.Difficulty);
            int placed = 0;

            while (placed < bombCount)
            {
                int r = _rand.Next(board.Size);
                int c = _rand.Next(board.Size);
                if (!board.Cells[r, c].IsBomb)
                {
                    board.Cells[r, c].IsBomb = true;
                    placed++;
                }
            }
        }

        public void CountBombsNearby(BoardModel board)
        {
            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    if (board.Cells[r, c].IsBomb)
                    {
                        board.Cells[r, c].NumberOfBombNeighbors = 9;
                        continue;
                    }

                    int count = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nr = r + i, nc = c + j;
                            if (nr >= 0 && nr < board.Size && nc >= 0 && nc < board.Size)
                                if (board.Cells[nr, nc].IsBomb)
                                    count++;
                        }
                    }
                    board.Cells[r, c].NumberOfBombNeighbors = count;
                }
            }
        }
    }
}
