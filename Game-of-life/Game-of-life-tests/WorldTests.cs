using System.Collections.Generic;
using Game_of_life;
using NUnit.Framework;

namespace Game_of_life_tests
{
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void TickMethodKillsLoneCells()
        {
            var cell = new Cell(State.Alive);
            var world = new World(new List<Cell> { cell });

            world.Tick();

            Assert.AreEqual(State.Dead, cell.State);
        }
    }
}