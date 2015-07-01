using System.Collections.Generic;

namespace Game_of_life
{
    public class World
    {
        private readonly IList<Cell> _cells = new List<Cell>();

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
}