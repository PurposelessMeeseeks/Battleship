﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;


namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvailablePlacementsReturns2SequenceForShip3SquaresLongOnGrid1x4()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        public void GetAvailablePlacementsReturns3SequenceForShip3SquaresLongOnGrid5x1()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        public void GetAvailablePlacementsReturns100SequenceForShip3SquaresLongOnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var placements = grid.GetAvailablePlacements(1);
            Assert.AreEqual(100, placements.Count());
        }

        public void GetAvailablePlacementsReturns3SequenceForShip2SquaresLongOnGrid1x6WithSquare0_2Eliminated()
        {
            Grid grid = new Grid(1, 6);
            grid.Eliminate(new List<Square> { new Square(0, 2) });
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }

        public void GetAvailablePlacementsReturns2SequenceForShip2SquaresLongOnGrid5x1WithSquare1_0Eliminated()
        {
            Grid grid = new Grid(5, 1);
            grid.Eliminate(new List<Square> { new Square(1, 0) });
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(2, placements.Count());
        }
    }
}
