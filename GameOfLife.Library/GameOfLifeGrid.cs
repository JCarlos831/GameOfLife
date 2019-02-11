using System;

namespace GameOfLife.Library
{
    public class GameOfLifeGrid
    {
        public int gridHeight { get; private set; }
        public int gridWidth { get; private set; }

        public CellState[,] CurrentState;
        private CellState[,] nextState;

        public GameOfLifeGrid(int height, int width)
        {
            gridHeight = height;
            gridWidth = width;
            
            if (gridHeight <= 0 || gridWidth <= 0)
                throw new Exception("Grid cannot have zero or negative values");

            CurrentState = new CellState[gridHeight, gridWidth];
            nextState = new CellState[gridHeight, gridWidth];

            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    CurrentState[i, j] = CellState.Dead;
                }
        }

        public void UpdateState()
        {
            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    int liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] =
                        GameOfLifeRules.GetNewState(CurrentState[i, j], liveNeighbors);
                }

            CurrentState = nextState;
            nextState = new CellState[gridHeight, gridWidth];
        }

        public void Randomize()
        {
            Random random = new Random();

            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    int next = random.Next(2);
                    CellState newState = next < 1 ? CellState.Dead : CellState.Alive;
                    CurrentState[i, j] = newState;
                }
        }

        private int GetLiveNeighbors(int positionX, int positionY)
        {
            int liveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if (neighborX >= 0 && neighborX < gridHeight &&
                        neighborY >= 0 && neighborY < gridWidth)
                    {
                        if (CurrentState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbors++;
                    }
                }

            return liveNeighbors;
        }
    }
}