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
            var squares = new List<Square> { new Square(4, 3), new Square(4,4), new Square(4, 5), new Square(4, 6) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }
        [TestMethod]
        public void ToEliminateReturns2SqauresForShip_3to_4()
        {
            var squares = new List<Square> { new Square(0, 3), new Square(0, 4) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }
        [TestMethod]
        public void ToEliminateReturns8SqauresForShip3_9to4_9()
        {
            var squares = new List<Square> { new Square(3, 9), new Square(4, 9) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }
        [TestMethod]
        public void ToEliminateReturns12SqauresForShip7_5to9_5()
        {
            var squares = new List<Square> { new Square(7, 5), new Square(8, 8), new Square(9, 5) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }
        [TestMethod]
        public void ToEliminateReturns12SqauresForShip0_5to1_5()
        {
            var squares = new List<Square> { new Square(0, 5), new Square(1, 5), new Square(4, 6) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }
    }
}
