using System.Collections.Generic;
using Game_of_life;
using NUnit.Framework;

namespace Game_of_life_tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void TestConstructACell()
        {
            var cell = new Cell(State.Alive);
            var cell2 = new Cell(State.Alive);
            cell.AddNeighbours(cell2);
            cell2.AddNeighbours(cell);
        }
        
        [Test]
        public void ACellWithOneAliveNeighbourShouldDie()
        {
            var cell = new Cell(State.Alive);
            var cell2 = new Cell(State.Alive);
            cell.AddNeighbours(cell2);
            cell2.AddNeighbours(cell);

            Assert.AreEqual(State.Dead, cell.GetNextState());
        }

        [Test]
        public void ACellWithTwoAliveNeighboursShouldStayAlive()
        {
            var cell = new Cell(State.Alive);
            cell.AddNeighbours(new Cell(State.Alive), new Cell(State.Alive), new Cell(State.Alive));

            Assert.AreEqual(State.Alive, cell.GetNextState());
        }

        [Test]
        public void ADeadCellWithThreeAliveNeighboursShouldBeBorn()
        {
            var cell = new Cell(State.Dead);
            cell.AddNeighbours(new Cell(State.Alive), new Cell(State.Alive), new Cell(State.Alive));

            Assert.AreEqual(State.Alive, cell.GetNextState());
        }
    }
}
