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
            var squares = new List<Square> { new Square(4, 3), new Square(4, 5), new Square(4, 6) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            Assert.AreEqual(18, result.Count());
            Assert.IsTrue(result.Contains(new Square(3, 2)));
            Assert.IsTrue(result.Contains(new Square(5, 2)));
            Assert.IsTrue(result.Contains(new Square(3, 7)));
            Assert.IsTrue(result.Contains(new Square(5, 7)));
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShip0_3To0_4()
        {
            var squares = new List<Square> { new Square(0, 3), new Square(0, 4) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            Assert.AreEqual(8, result.Count());
            Assert.IsTrue(result.Contains(new Square(0, 2)));
            Assert.IsTrue(result.Contains(new Square(0, 5)));
            Assert.IsTrue(result.Contains(new Square(1, 2)));
            Assert.IsTrue(result.Contains(new Square(1, 3)));
            Assert.IsTrue(result.Contains(new Square(1, 4)));
            Assert.IsTrue(result.Contains(new Square(1, 5)));
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShip3_9To4_9()
        {
            var squares = new List<Square> { new Square(3, 9), new Square(4, 9) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            Assert.AreEqual(8, result.Count());
            Assert.IsTrue(result.Contains(new Square(2, 8)));
            Assert.IsTrue(result.Contains(new Square(2, 9)));
            Assert.IsTrue(result.Contains(new Square(3, 8)));
            Assert.IsTrue(result.Contains(new Square(4, 8)));
            Assert.IsTrue(result.Contains(new Square(5, 8)));
            Assert.IsTrue(result.Contains(new Square(5, 9)));
        }

        [TestMethod]
        public void ToEliminateReturns12SquaresForShip7_5To9_5()
        {
            var squares = new List<Square> { new Square(7, 5), new Square(8, 5), new Square(9, 5) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            Assert.AreEqual(12, result.Count());
            Assert.IsTrue(result.Contains(new Square(6, 4)));
            Assert.IsTrue(result.Contains(new Square(6, 5)));
            Assert.IsTrue(result.Contains(new Square(6, 6)));
            Assert.IsTrue(result.Contains(new Square(7, 4)));
            Assert.IsTrue(result.Contains(new Square(7, 6)));
            Assert.IsTrue(result.Contains(new Square(8, 4)));
            Assert.IsTrue(result.Contains(new Square(8, 6)));
            Assert.IsTrue(result.Contains(new Square(9, 4)));
            Assert.IsTrue(result.Contains(new Square(9, 6)));
        }

        [TestMethod]
        public void ToEliminateReturns9SquaresForShip0_5To1_5()
        {
            var squares = new List<Square> { new Square(0, 5), new Square(1, 5) };
            SurroundingSquaresEliminator eliminator = new SurroundingSquaresEliminator(10, 10);
            var result = eliminator.ToEliminate(squares);

            Assert.AreEqual(9, result.Count());
            Assert.IsTrue(result.Contains(new Square(0, 4)));
            Assert.IsTrue(result.Contains(new Square(0, 6)));
            Assert.IsTrue(result.Contains(new Square(1, 4)));
            Assert.IsTrue(result.Contains(new Square(1, 6)));
            Assert.IsTrue(result.Contains(new Square(2, 4)));
            Assert.IsTrue(result.Contains(new Square(2, 5)));
            Assert.IsTrue(result.Contains(new Square(2, 6)));
        }

    }
}






//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Vsite.Oom.Battleship.Model.UnitTests
//{
//    [TestClass]
//    public class TestSorroundingSquaresEliminator
//    {

//        [TestMethod]
//        public void ToEliminateReturnsEighteenSquaresToEliminateForShipWithDimensionFourByThree()
//        {
//            var ship = new List<Square> { new Square(7, 3), new Square(7, 4), new Square(7, 5), new Square(7, 6) };
//            var eliminator = new SorroundingSquaresEliminator(10, 10);
//            var toEliminate = eliminator.ToEliminate(ship);

//            Assert.AreEqual(18, toEliminate.Count());

//            // all sorrounding squares
//            Assert.IsTrue(toEliminate.Contains(new Square(6, 2)));
//            Assert.IsTrue(toEliminate.Contains(new Square(8, 2)));
//            Assert.IsTrue(toEliminate.Contains(new Square(8, 7)));
//            Assert.IsTrue(toEliminate.Contains(new Square(6, 7)));
//        }

//        [TestMethod]
//        public void ToEliminateReturnsEightSquaresWhenShipIsPlacedOnTheFirstColumnVertically()
//        {
//            var ship = new List<Square> { new Square(0, 5), new Square(0, 6) };
//            var eliminator = new SorroundingSquaresEliminator(10, 10);
//            var toEliminate = eliminator.ToEliminate(ship);

//            Assert.AreEqual(8, toEliminate.Count());

//            // all sorrounding squares
//            Assert.IsTrue(toEliminate.Contains(new Square(0, 4)));
//            Assert.IsTrue(toEliminate.Contains(new Square(1, 4)));
//            Assert.IsTrue(toEliminate.Contains(new Square(1, 7)));
//            Assert.IsTrue(toEliminate.Contains(new Square(0, 7)));
//        }

//        [TestMethod]
//        public void ToEliminateReturnsEightSquaresWhenShipIsPlacedOnTheFirsRowHorisontally()
//        {
//            var ship = new List<Square> { new Square(0, 0), new Square(0, 1) };
//            var eliminator = new SorroundingSquaresEliminator(10, 10);
//            var toEliminate = eliminator.ToEliminate(ship);

//            Assert.AreEqual(6, toEliminate.Count());

//            // all sorrounding squares
//            Assert.IsTrue(toEliminate.Contains(new Square(0, 0)));
//            Assert.IsTrue(toEliminate.Contains(new Square(1, 0)));
//            Assert.IsTrue(toEliminate.Contains(new Square(1, 2)));
//            Assert.IsTrue(toEliminate.Contains(new Square(0, 2)));
//        }


//        [TestMethod]
//        public void ToEliminateReturnsSixSquaresWhenShipIsPlacedInTheCorner()
//        {
//            var ship = new List<Square> { new Square(8, 9), new Square(9, 9) };
//            var eliminator = new SorroundingSquaresEliminator(10, 10);
//            var toEliminate = eliminator.ToEliminate(ship);

//            Assert.AreEqual(6, toEliminate.Count());

//            // all sorrounding squares
//            Assert.IsTrue(toEliminate.Contains(new Square(7, 8)));
//            Assert.IsTrue(toEliminate.Contains(new Square(7, 9)));
//            Assert.IsTrue(toEliminate.Contains(new Square(9, 8)));
//            Assert.IsTrue(toEliminate.Contains(new Square(9, 9)));
//        }

//        // TODO: test cases when ship is placed on the mirrored way as now ( to cover all sides of the rect ) 
//        // TODO: test cases for all ship dimensions, covered are 2 and 4, so 3 and 5 are missing
//    }
//}