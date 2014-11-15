using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_of_life;
using NUnit.Framework;

namespace Game_of_life_tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void TestInstantiates()
        {
            var alive = false;
            var cell = new Cell(alive);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestDeadness(Boolean value)
        {
            var cell = new Cell(value);
            Assert.AreEqual(value, cell.IsAlive);
        }

        [Test]
        public void TestAddNeighbour()
        {
            var otherCell = new Cell(true);

            var ourCell = new Cell(false);
            ourCell.AddNeighbour(otherCell, Direction.North);
            ourCell.tick();
            ourCell.tock();
            Assert.AreEqual(false, ourCell.IsAlive);
        }

        [Test]
        public void TestChangeState()
        {
            var otherCell = new Cell(true);
            var otherCell2 = new Cell(true);
            var otherCell3 = new Cell(true);

            var ourCell = new Cell(false);

            ourCell.AddNeighbour(otherCell, Direction.North);
            ourCell.AddNeighbour(otherCell2, Direction.NorthEast);
            ourCell.AddNeighbour(otherCell3, Direction.NorthWest);
            ourCell.tick();
            ourCell.tock();
            Assert.AreEqual(true, ourCell.IsAlive);
        }
    }
}
