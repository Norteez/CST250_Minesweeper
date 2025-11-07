namespace MinesweeperClassLibrary.Models
{
    public class CellModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsVisited { get; set; } = false;
        public bool IsBomb { get; set; } = false;
        public bool IsFlagged { get; set; } = false;
        public int NumberOfBombNeighbors { get; set; } = 0;
        public bool HasSpecialReward { get; set; } = false;

        public CellModel(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
