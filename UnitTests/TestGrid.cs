using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturnsSequencesForShip3SquaresLongOnGrid1x4()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }


        [TestMethod]
        public void GetAvailablePlacementsReturnsSequencesForShip3SquaresLongOnGrid5x1()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }
    }
}
