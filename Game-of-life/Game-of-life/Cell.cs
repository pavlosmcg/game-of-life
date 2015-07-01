using System.Collections.Generic;
using System.Linq;

namespace Game_of_life
{
    public class Cell
    {
        private IList<Cell> _neighbours = new List<Cell>();

        public Cell(State state)
        {
            State = state;
        }

        public State State { get; set; }

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

            if (liveNeighbourCount == 3)
                return State.Alive;

            return State.Dead;
        }
    }
}