﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSurroundingSquareEliminator
    {
        [TestMethod]
        public void ToelimnateReturns18SquaresForShip4_3To4_6()
        {
            var squares = new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }

        [TestMethod]
        public void ToelimnateReturns2SquaresForShip0_3To0_4()
        {
            var squares = new List<Square> { new Square(4, 3), new Square(4, 4)};
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }

        [TestMethod]
        public void ToelimnateReturns12SquaresForShip7_5To9_5()
        {
            var squares = new List<Square> { new Square(7, 5), new Square(9, 5) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }

        [TestMethod]
        public void ToelimnateReturns8SquaresForShip3_9To4_9()
        {
            var squares = new List<Square> { new Square(3, 9), new Square(4, 9) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }

        [TestMethod]
        public void ToelimnateReturns9SquaresForShip0_5To1_5()
        {
            var squares = new List<Square> { new Square(0, 5), new Square(1, 5) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);
            Assert.Fail();
        }


    }
}
