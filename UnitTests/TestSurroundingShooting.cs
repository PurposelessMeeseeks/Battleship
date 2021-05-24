using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSurroundingShooting
    {
        private Square square;

        [TestMethod]
        public void NextTargetSelectsOneOfSquaresSurroundingSquare3_3()
        {
            Grid grid = new Grid(10, 10);
            Square sqaure = new Square(3, 3);
            var shooting = new SurroundingShooting(grid, square, 3);
            Assert.IsTrue(shooting.NextTarget().Equals(new Square(2, 3)) || shooting.NextTarget().Equals(new Square(3, 4)) || shooting.NextTarget().Equals(new Square(4, 3))
                || shooting.NextTarget().Equals(new Square(3, 2)));
        }
    }
}
