using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestShipwight
    {
        [TestMethod]
        public void CreateFleetReturnsValidFleet()
        {
            List<int> shipLenghts = new List<int> { 5, 4, 3, 2, 1 };
            var shipwright = new Shipwight(10, 10, shipLenghts);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(5, fleet.Ships);
        }
    }
}
