using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructorCreatesAShipFormSquaresProvided()
        {
            var sqaures = new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) };
            Ship ship = new Ship(squares);
            Assert.AreEqual(4, ship.Sqaures.Count());
            Assert.IsTrue(ship.Sqaures.Contains(sqaures[0]));
            Assert.IsTrue(ship.Sqaures.Contains(sqaures[1]));
            Assert.IsTrue(ship.Sqaures.Contains(sqaures[2]));
        }
    }
}
