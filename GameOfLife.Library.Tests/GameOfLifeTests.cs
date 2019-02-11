using System;
using NUnit.Framework;

namespace GameOfLife.Library.Tests
{
    // Any live cell with fewer than two neighbors dies
    // Any live cell with two or three live neighbors lives
    // Any live cell with more than three neighbors dies
    // Any dead cell with exactly three live neighbors becomes a live cell

    [TestFixture]
    public class GameOfLifeRulesTests
    {
        [Test]
        public void Live_Cell_With_Fewer_Than_Two_Live_Neighbors_Dies(
            [Values(CellState.Alive)] CellState currentState, [Values(0, 1)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void Live_Cell_With_Two_Or_Three_Live_Neighbors_Lives(
            [Values(CellState.Alive)] CellState currentState, [Values(2, 3)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void Live_Cell_With_More_Than_Three_Neighbors_Dies(
            [Values(CellState.Alive)] CellState currenstate, [Range(4, 8)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currenstate, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void Dead_Cell_With_Exactly_Three_Neighbors_Becomes_A_Live_Cell(
            [Values(CellState.Dead)] CellState currentState, [Values(3)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void Dead_Cell_With_Less_Than_Three_Neighbors_Stays_Dead(
            [Values(CellState.Dead)] CellState currentState, [Range(0, 2)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void Dead_Cell_With_More_Than_Three_Neighbors_Stays_Dead(
            [Values(CellState.Dead)] CellState currentState, [Range(4, 8)] int liveNeighbors)
        {
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [TestFixture]
        public class GameOfLifeGridTests
        {
            [Test]
            public void New_Grid_Given_Height_and_Width_Is_Not_Null()
            {
                GameOfLifeGrid gameOfLifeGrid = new GameOfLifeGrid(60, 60);
                
                Assert.That(gameOfLifeGrid, Is.Not.Null);
            }
            
            [Test]
            public void New_Grid_Given_Height_and_Width_Has_Correct_Dimensions()
            {
                GameOfLifeGrid gameOfLifeGrid = new GameOfLifeGrid(60, 60);
                
                Assert.That(gameOfLifeGrid.gridHeight, Is.EqualTo(60));
                Assert.That(gameOfLifeGrid.gridWidth, Is.EqualTo(60));
            }
        }
    }
}
