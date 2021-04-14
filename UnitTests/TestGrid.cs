using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturn2SequancesForShip3SquaresLongOnGrid1x4()
        {
            Grid grid = new Grid(1, 4);
            var placement = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placement.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturn3SequancesForShip3SquaresLongOnGrid5x1()
        {
            Grid grid = new Grid(5, 1);
            var placement = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placement.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturn100SequancesForShip1SquaresLongOnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var placement = grid.GetAvailablePlacements(1);
            Assert.AreEqual(100, placement.Count());
        }
    }
}
