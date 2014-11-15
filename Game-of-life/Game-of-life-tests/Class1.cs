using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Game_of_life_tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Tick_CreatesANewNeighbourhood()
        {
            var neighbourhood = new Neighbourhood();

            var next = neighbourhood.Tick();

            Assert.That(next, Is.Not.SameAs(neighbourhood));
        }

        [Test]
        public void Tick_ReturnsADeadNeighbourhood_WhenTheOriginalHasOnlyOneLiveCell()
        {
            var neighbourhood = new Neighbourhood(new Position(2,2));

            var next = neighbourhood.Tick();

            Assert.That(next, Is.SameAs(Neighbourhood.Dead));
        }
    }

    public class Position
    {
        private int x, y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    public class Neighbourhood
    {
        public Neighbourhood Tick()
        {
            return Dead;
        }

        private static readonly Neighbourhood dead = new Neighbourhood();

        public Neighbourhood(params Position[] liveCellPositions)
        {
            
        }

        public static Neighbourhood Dead
        {
            get { return dead; }
        }
    }
}
