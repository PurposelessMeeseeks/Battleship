using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSurroundingSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturns18SqauresForShip4_3to4_6()
        {
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            List<Square> shipSquares = new List<Square>
            {
                new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6)
            };
            var toEliminate = eliminator.ToEliminate(shipSquares);
            Assert.AreEqual(18, toEliminate.Count());
            foreach (var square in shipSquares)
            {
                Assert.IsTrue(toEliminate.Contains(square));
            }
            Assert.IsTrue(toEliminate.Contains(new Square(3, 2)));
            Assert.IsTrue(toEliminate.Contains(new Square(5, 2)));
            Assert.IsTrue(toEliminate.Contains(new Square(3, 7)));
            Assert.IsTrue(toEliminate.Contains(new Square(5, 7)));
        }
        [TestMethod]
        public void ToEliminateReturns2SqauresForShip_3to_4()
        {
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            List<Square> shipSquares = new List<Square>
            {
                new Square(0,3), new Square(0,4)
            };
            var toEliminate = eliminator.ToEliminate(shipSquares);
            Assert.AreEqual(18, toEliminate.Count());
            foreach (var square in shipSquares)
            {
                Assert.IsTrue(toEliminate.Contains(square));
            }
            Assert.IsTrue(toEliminate.Contains(new Square(0, 2)));
            Assert.IsTrue(toEliminate.Contains(new Square(1, 2)));
            Assert.IsTrue(toEliminate.Contains(new Square(0, 5)));
            Assert.IsTrue(toEliminate.Contains(new Square(1, 5)));
        }
        [TestMethod]
        public void ToEliminateReturns8SqauresForShip3_9to4_9()
        {
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            List<Square> shipSquares = new List<Square>
            {
                new Square(3,9), new Square(4,9)
            };
            var toEliminate = eliminator.ToEliminate(shipSquares);
            Assert.AreEqual(8, toEliminate.Count());
            foreach (var square in shipSquares)
            {
                Assert.IsTrue(toEliminate.Contains(square));
            }
            Assert.IsTrue(toEliminate.Contains(new Square(2, 8)));
            Assert.IsTrue(toEliminate.Contains(new Square(2, 9)));
            Assert.IsTrue(toEliminate.Contains(new Square(5, 8)));
            Assert.IsTrue(toEliminate.Contains(new Square(5, 9)));
        }
        [TestMethod]
        public void ToEliminateReturns12SqauresForShip7_5to9_5()
        {
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            List<Square> shipSquares = new List<Square>
            {
                new Square(7,5), new Square(8,5), new Square(9,5)
            };
            var toEliminate = eliminator.ToEliminate(shipSquares);
            Assert.AreEqual(12, toEliminate.Count());
            foreach (var square in shipSquares)
            {
                Assert.IsTrue(toEliminate.Contains(square));
            }
            Assert.IsTrue(toEliminate.Contains(new Square(6, 4)));
            Assert.IsTrue(toEliminate.Contains(new Square(6, 6)));
            Assert.IsTrue(toEliminate.Contains(new Square(9, 4)));
            Assert.IsTrue(toEliminate.Contains(new Square(9, 6)));
        }
        [TestMethod]
        public void ToEliminateReturns12SqauresForShip0_5to1_5()
        {
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            List<Square> shipSquares = new List<Square>
            {
                new Square(5,0), new Square(5,1)
            };
            var toEliminate = eliminator.ToEliminate(shipSquares);
            Assert.AreEqual(9, toEliminate.Count());
            foreach (var square in shipSquares)
            {
                Assert.IsTrue(toEliminate.Contains(square));
            }
            Assert.IsTrue(toEliminate.Contains(new Square(4, 0)));
            Assert.IsTrue(toEliminate.Contains(new Square(4, 2)));
            Assert.IsTrue(toEliminate.Contains(new Square(6, 0)));
            Assert.IsTrue(toEliminate.Contains(new Square(6, 2)));
        }
    }
}

