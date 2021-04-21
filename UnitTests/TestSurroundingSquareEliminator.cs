using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSurroundingSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturns18SquaresForShip4_3To4_6()
        {
            var squares = new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            squares.Add(new Square(3, 2));
            squares.Add(new Square(5, 2));
            squares.Add(new Square(3, 7));
            squares.Add(new Square(5, 7));

            squares.ForEach(s => Assert.IsTrue(result.Contains(s)));
            Assert.AreEqual(18, result.Count());
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShip3_9To4_9()
        {
            var squares = new List<Square> { new Square(3, 9), new Square(4, 9) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            squares.Add(new Square(2, 8));
            squares.Add(new Square(2, 9));
            squares.Add(new Square(5, 8));
            squares.Add(new Square(5, 9));

            squares.ForEach(s => Assert.IsTrue(result.Contains(s)));
            Assert.AreEqual(8, result.Count());
        }
            
        [TestMethod]
        public void ToEliminateReturns12SquaresForShip7_5To9_5()
        {
            var squares = new List<Square> { new Square(7, 5), new Square(8, 5), new Square(9, 5) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            squares.Add(new Square(6, 4));
            squares.Add(new Square(6, 6));
            squares.Add(new Square(9, 4));
            squares.Add(new Square(9, 6));

            squares.ForEach(s => Assert.IsTrue(result.Contains(s)));
            Assert.AreEqual(12, result.Count());
        }

        [TestMethod]
        public void ToEliminateReturns9SquaresForShip0_5To1_5()
        {
            var squares = new List<Square> { new Square(0, 5), new Square(1, 5) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            squares.Add(new Square(0, 4));
            squares.Add(new Square(0, 6));
            squares.Add(new Square(2, 4));
            squares.Add(new Square(2, 6));

            squares.ForEach(s => Assert.IsTrue(result.Contains(s)));
            Assert.AreEqual(9, result.Count());
        }
    }
}
