using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Vsite.Oom.Battleship.Model.UnitTests {


    [TestClass]
    public class TestGrid {

        [TestMethod]
        public void GetAvailablePlacementsReturns2SequencesForShip3SquaresLongOnGrid1x4() {

            Grid grid = new Grid(1,4);

            var placements  = grid.GetAvailablePlacements(3); ;
            Assert.AreEqual(2,placements.Count());
        
        }


        [TestMethod]
        public void GetAvailablePlacementsReturns2SequencesForShip3SquaresLongOnGrid5x1() {

            Grid grid = new Grid(5,1);

            var placements  = grid.GetAvailablePlacements(3); ;

            Assert.AreEqual(3,placements.Count());
        
        }

}
}
