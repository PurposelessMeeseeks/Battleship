using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class FleetTest
    {
        [TestMethod]
        public void ConstructionOfTheFleetConstructsFleetWithZeroShips()
        {
            Fleet fleet = new Fleet();

            Assert.AreEqual(0, fleet.Ships.Count());
        }

        [TestMethod]
        public void CallToCreateShipAddsNewShipToFleet()
        {
            Fleet fleet = new Fleet();
            List<Square> ship = new List<Square> { new Square(1, 2), new Square(1, 3), new Square(1, 4) };
            fleet.CreateShip(ship);

            Assert.AreEqual(1, fleet.Ships.Count());

            ship = new List<Square> { new Square(5, 7), new Square(6, 7), new Square(7, 7) };
            fleet.CreateShip(ship);

            Assert.AreEqual(2, fleet.Ships.Count());
        }

    }
}
