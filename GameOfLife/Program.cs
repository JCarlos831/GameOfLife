using System;
using GameOfLife.Library;

// To get project running, set grid height and width on line 14 in 
// new GameOfLifeGrid(,)
// Height and Width must each be greater than zero
// Once the project is running, to get to the next generation
// press "Enter". To quit, type "q".

namespace GameOfLife
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GameOfLifeGrid grid = new GameOfLifeGrid(15, 60);
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
