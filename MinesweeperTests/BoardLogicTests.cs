using Xunit;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.BusinessLogicLayer;

namespace MinesweeperTests
{
    public class BoardLogicTests
    {
        [Fact]
        public void SetupBombs_ShouldPlaceBombs()
        {
            BoardModel board = new(8) { Difficulty = 0.1 };
            BoardLogic logic = new();
            logic.SetupBombs(board);

            int bombCount = 0;
            foreach (var cell in board.Cells)
                if (cell.IsBomb) bombCount++;

            Assert.True(bombCount > 0);
        }

        [Fact]
        public void CountBombsNearby_ShouldSetCorrectCounts()
        {
            BoardModel board = new(3);
            board.Cells[1, 1].IsBomb = true;
            BoardLogic logic = new();
            logic.CountBombsNearby(board);

            Assert.Equal(9, board.Cells[1, 1].NumberOfBombNeighbors);
            Assert.True(board.Cells[0, 0].NumberOfBombNeighbors > 0);
        }
    }
}
