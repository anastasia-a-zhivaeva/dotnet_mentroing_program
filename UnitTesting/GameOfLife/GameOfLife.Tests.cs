namespace GameOfLife
{
    public class GameOfLifeTests
    {
        [Fact]
        public void CalculateNextGeneration_AllDeadCellsRemainDead()
        {
            var dc = GameOfLifeProcessor.DeadCell;
            var cellsGrid = new string[3, 3] 
            { 
                { dc, dc, dc }, 
                { dc, dc, dc }, 
                { dc, dc, dc } 
            };

            string[,] result = GameOfLifeProcessor.CalculateNextGeneration(cellsGrid);


            foreach(var cell in result)
            {
                Assert.Equal(".", cell);
            }
        }

        [Fact]
        public void CalculateNextGeneration_AliveCellsWithLessThan2AliveNeighboursBecomeDead()
        {
            var dc = GameOfLifeProcessor.DeadCell;
            var ac = GameOfLifeProcessor.AliveCell;
            var cellsGrid = new string[3, 3]
            {
                { dc, dc, dc },
                { dc, ac, dc },
                { dc, dc, dc }
            };

            string[,] result = GameOfLifeProcessor.CalculateNextGeneration(cellsGrid);


            foreach (var cell in result)
            {
                Assert.Equal(".", cell);
            }
        }
    }
}