using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTest
{
    [TestClass]
    public class TestShipwringht
    {
        [TestMethod]
        public void CreateFleetReturnsValidFleet()
        {
            List<int> shipLenghts = new List<int> { 5, 4, 3, 2, 1 };
            var shipwright = new Shipwringht(10, 10, shipLenghts);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(5, fleet.Ships);
        }
    }
}
