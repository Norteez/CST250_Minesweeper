using System;

namespace MinesweeperClassLibrary.Models
{
    public enum GameState { InProgress, Won, Lost }

    public class BoardModel
    {
        public int Size { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public CellModel[,] Cells { get; set; }
        public double Difficulty { get; set; }
        public int RewardsRemaining { get; set; } = 0;
        public GameState State { get; set; } = GameState.InProgress;

        public BoardModel(int size)
        {
            Size = size;
            Cells = new CellModel[size, size];
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    Cells[r, c] = new CellModel(r, c);
        }
    }
}
