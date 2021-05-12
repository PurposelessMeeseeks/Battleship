using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTest
{
    [TestClass]
    public class TestSurroundingShooting
    {
        [TestMethod]
        public void NextTargetSelectsOneOfSquaresSurroundingSquare3_3()
        {
            //dovrsit
            Grid grid = new Grid(10, 10);
            Square square = new Square(3, 3);
            //var shooting = new LinearShooting(grid, square);
            //Assert.IsTrue(shooting.NextTarget().Equals(new Square(2,3)) ||
            //    shooting.NextTarget().Equals(new Square(3, 4)));
        }
    }
    
}
