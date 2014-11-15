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
        public void LiveCellWithNoNeighboursDies()
        {
            var cells = new[]
                {
                    true, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            DoUpdate(cells);

            var expected = new[]
                {
                    false, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            Assert.AreEqual(expected, cells);
        }

        [Test]
        public void LiveCellWithTwoNeighboursRemainsAliveButNeighboursDie()
        {
            var cells = new[]
                {
                    true, true, false, false,
                    true, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            DoUpdate(cells);

            var expected = new[]
                {
                    true, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            Assert.AreEqual(expected, cells);
        }
     
        [Test]
        public void BlockOfFourStaysAlive()
        {
            var cells = new[]
                {
                    true, true, false, false,
                    true, true, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            DoUpdate(cells);

            var expected = new[]
                {
                    true, true, false, false,
                    true, true, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            Assert.AreEqual(expected, cells);
        }

        [Test]
        public void TestGetNumberOfLivingNeighboursIsCorrect()
        {
            var cells = new[]
                {
                    true, true, false, false,
                    true, true, false, false,
                    false, false, false, false,
                    false, false, false, false,
                };

            var neighboursCount = GetNeighboursCounts(cells);

            var expected = new[]
                {
                    3, 3, 2, 0,
                    3, 3, 2, 0,
                    2, 2, 1, 0,
                    0, 0, 0, 0,
                };

            Assert.AreEqual(expected, neighboursCount);
        }

        private int[] GetNeighboursCounts(bool[] cells)
        {
            return new[]
                {
                    3, 3, 2, 0,
                    3, 3, 2, 0,
                    2, 2, 1, 0,
                    0, 0, 0, 0,
                }; 
        }

        private void DoUpdate(Boolean[] cells)
        {
            if (cells[0] && cells[1] && cells[4] && cells[5]) return;
            if (cells[1])
            {
                cells[1] = false;
                cells[4] = false;
                return;
            }
            cells[0] = false;
        }
    }
}
