using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Game_of_life_tests
{
    public enum State { Dead, Alive }

    [TestFixture]
    public class Class1
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

        [Test]
        public void TickMethodKillsLoneCells()
        {
            var cell = new Cell(State.Alive);
            var world = new World(new List<Cell> {cell});

            world.Tick();

            Assert.AreEqual(State.Dead, cell.State);
        }
    }

    public class World
    {
        private IList<Cell> _cells = new List<Cell>();

        public World(IList<Cell> cells)
        {
            _cells = cells;
        }

        public void Tick()
        {
            var newStates = new Dictionary<Cell, State>();
            foreach (var cell in _cells)
            {
                newStates[cell] = cell.GetNextState();
            }
            foreach (var cell in _cells)
            {
                cell.State = newStates[cell];
            }
        }
    }

    public class Cell
    {
        private State _state;
        private IList<Cell> _neighbours = new List<Cell>();

        public Cell(State state)
        {
            _state = state;
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void AddNeighbours(params Cell[] neighbours)
        {
            _neighbours = neighbours;
        }

        public State GetNextState()
        {
            var liveNeighbourCount = _neighbours.Count(x => x.State == State.Alive);
            if (State == State.Alive)
            {
                switch (liveNeighbourCount)
                {
                    case 2: 
                    case 3:
                        return State.Alive;
                }
            }
            else
            {
                if (liveNeighbourCount == 3)
                {
                    return State.Alive;
                }
            }

            return State.Dead;
        }
    }
}
