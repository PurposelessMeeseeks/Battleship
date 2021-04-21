using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests1
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturns3SequencesForShip2SquaresLongOnGrid1x6WithSquare0_2Eliminated()
        {
            Grid grid = new Grid(1, 6)
            grid.Eliminate(new List<Square> { new Square(0, 2) });
            var placements
        }
    }
}
