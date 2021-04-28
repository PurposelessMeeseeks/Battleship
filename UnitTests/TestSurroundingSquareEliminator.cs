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
            Assert.Fail();
            // TODO: dz
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShip0_3To0_4()
        {
            var squares = new List<Square> { new Square(0, 3), new Square(0, 4) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
            // TODO: dz
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShip3_9To4_9()
        {
            var squares = new List<Square> { new Square(3, 9), new Square(4, 9)};
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
            // TODO: dz
        }       
        
        [TestMethod]
        public void ToEliminateReturns12SquaresForShip7_5To9_5()
        {
            var squares = new List<Square> { new Square(7, 5), new Square(8, 8), new Square(9, 5) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
            // TODO: dz
        }        
        
        [TestMethod]
        public void ToEliminateReturns12SquaresForShip0_5To1_5()
        {
            var squares = new List<Square> { new Square(0, 5), new Square(1, 5) };
            SurroundingSquareEliminator eliminator = new SurroundingSquareEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
            // TODO: dz
        }
    }
}
