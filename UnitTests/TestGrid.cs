using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturns2SequencesForShip3SquaresLongOnGrid1x4()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }           
        
        [TestMethod]
        public void GetAvailablePlacementsReturns100SequencesForShip1SquaresLongOnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var placements = grid.GetAvailablePlacements(1);
            Assert.AreEqual(100, placements.Count());
        }       

    }
}
