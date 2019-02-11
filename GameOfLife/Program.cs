using System;
using GameOfLife.Library;

// Once the project is running, to get to the next generation
// press "Enter". To quit, type "q".

namespace GameOfLife
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GameOfLifeGrid grid = new GameOfLifeGrid(-1, -1);
            grid.Randomize();

            ShowGrid(grid.CurrentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentState.GetUpperBound(1) + 1;

            foreach (CellState state in currentState)
            {
                string output;
                if (state == CellState.Alive)
                {
                    output = "0";
                }
                else
                    output = ".";                
                Console.Write(output);
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
