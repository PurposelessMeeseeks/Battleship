﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetReturnsVaildFleet()
        {
            List<int> shipLenghts = new List<int> { 5, 4, 3, 2, 1 };
            var shipwright = new Shipwright(10, 10, shipLenghts);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(5, fleet.Ships.Count());
        }
    }
}
