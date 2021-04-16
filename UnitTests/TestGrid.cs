using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturnsTwoSequencesForShipThreeSquaresLongOnGridOneByFour()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);

            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturnsThreeSequencesForShipThreeSquaresLongOnGridFiveByOne()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);

            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacesReturnsOneHundredSequencesForShipOneSquareLongOnGreedTenByTen()
        {
            Grid grid = new Grid(10, 10);
            var placements = grid.GetAvailablePlacements(1);

            Assert.AreEqual(100, placements.Count());
        }
    }
}
