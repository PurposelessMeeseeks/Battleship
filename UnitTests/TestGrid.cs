using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetSequencesReturns100ArraysForAShipOfLength1SquareOnGridWith10Rows10Columns()
        {
            Grid grid = new Grid(10, 10);
            var placements = grid.GetSequences(1);
            Assert.AreEqual(100, placements.Count());
        }

        [TestMethod]
        public void GetSequencesReturns2ArraysForAShipOfLength3SquaresOnGridWith1Row4Columns()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetSequences(3);
            Assert.AreEqual(2, placements.Count());
            Assert.AreEqual(3, placements.ElementAt(0).Count());
            Assert.AreEqual(3, placements.ElementAt(1).Count());
        }

        [TestMethod]
        public void GetSequencesReturns3ArraysForAShipOfLength3SquaresOnGridWith5Rows1Column()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetSequences(3);
            Assert.AreEqual(3, placements.Count());
            Assert.AreEqual(3, placements.ElementAt(0));
            Assert.AreEqual(3, placements.ElementAt(1));
            Assert.AreEqual(3, placements.ElementAt(2));
        }

    }
}
