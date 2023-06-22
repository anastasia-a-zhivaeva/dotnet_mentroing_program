﻿namespace GameOfLife
{
    internal static class GameOfLifeProcessor
    {
        private static readonly int[,] _neighbours = new int[8, 2]
        {
            { 0, 1 },
            { 1, 0 },
            { 0, -1 },
            { -1, 0 },
            { 1, 1 },
            { -1, -1 },
            { -1, 1 },
            { 1, -1 },
        };

        public static readonly string AliveCell = "*";
        public static readonly string DeadCell = ".";

        internal static string[,] CalculateNextGeneration(string[,] cellsGrid)
        {
            var nextGen = (string[,])cellsGrid.Clone();
            for (int x = 0; x < cellsGrid.GetLength(0); x++)
            {
                for (int y = 0; y < cellsGrid.GetLength(1); y++)
                {
                    
                    var aliveNeighbours = CalculateAliveNeighbours(cellsGrid);

                    nextGen[x, y] = CalculateNextGenCell(aliveNeighbours, cellsGrid[x, y]);
                }
            }

            return nextGen;
        }

        private static int CalculateAliveNeighbours(string [,] cellsGrid)
        {
            var aliveNeighbours = 0;

            for (int z = 0; z < _neighbours.GetLength(0); z++)
            {
                try
                {
                    var firstIndex = _neighbours[z, 0];
                    var secondIndex = _neighbours[z, 1];
                    if (cellsGrid[firstIndex, secondIndex] == AliveCell)
                    {
                        aliveNeighbours++;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // neighbour doesn't exist in this place
                }
            }

            return aliveNeighbours;
        }

        private static string CalculateNextGenCell(int aliveNeighbours, string currentGenCell)
        {
            if (currentGenCell == DeadCell)
            {
                if (aliveNeighbours > 3)
                {
                    return AliveCell;
                }
                else
                {
                    return DeadCell;
                }
            }
            else
            {
                if (aliveNeighbours < 2)
                {
                    return DeadCell;
                }
                else
                {
                    return currentGenCell;
                }
            }
        }
    }
}