using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTest
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructorCreateShipFromSquaresProvided()
        {
            List<Square> squares = new List<Square> { new Square(1, 2), new Square(1, 3), new Square(1, 4) };
            var ship = new Ship(squares);
            Assert.IsTrue(ship.Squares.Contains(squares[0]));
            Assert.IsTrue(ship.Squares.Contains(squares[1]));
            Assert.IsTrue(ship.Squares.Contains(squares[2]));

            Assert.IsFalse(ship.Squares.Contains(new Square(5, 4)));

        }



        [TestMethod]
        public void SquaresContainsOnlyGivenElementsInConstructor()
        {
            List<Square> squares = new List<Square> { new Square(1, 2), new Square(1, 3), new Square(1, 4) };
            var ship = new Ship(squares);
            

            Assert.IsFalse(ship.Squares.Contains(new Square(5, 4)));
            Assert.IsFalse(ship.Squares.Contains(new Square(1, 1)));
            Assert.IsFalse(ship.Squares.Contains(new Square(1, 5)));

        }
    }
}
