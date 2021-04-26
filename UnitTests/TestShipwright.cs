using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetReturnValidFleed()
        {
            List<int> shipLengths = new List<int> { 5, 4, 3, 2, 1, };
            var shipwright = new Shipwright(10, 10, shipLengths);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(5, fleet.Ships);
        }
    }
}
