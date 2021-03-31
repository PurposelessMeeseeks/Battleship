using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Vsite.Oom.Battleship.Model.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingSquareConstructorsRowAndColumn()
        {
            Square testingSquare = new Square(5, 4);
            Assert.AreEqual(5, testingSquare.row);
            Assert.AreEqual(4, testingSquare.column);
        }
    }
}
