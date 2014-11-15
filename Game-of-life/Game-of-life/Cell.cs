using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    public class Cell
    {
        public Cell(bool alive)
        {
            IsAlive = alive;
        }

        public bool IsAlive { get; set; }

        public void AddNeighbour(Cell otherCell, Direction direction)
        {
            _neighbours[direction] = otherCell;
        }

        private readonly IDictionary<Direction, Cell> _neighbours = new Dictionary<Direction, Cell>();
        private bool _intermediate_alive;

        public void tick()
        {
            var count = 0;
            foreach (var neighbour in _neighbours)
            {
                if(neighbour)
            }
            _intermediate_alive =
        }

        public void tock()
        {
            
        }
    }
}
