using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void SquareConstructorCreateASquareAtGivenRowAndColumn()
        {
            Square s = new Square(5, 4);
            Assert.AreEqual(5, s.Row); 
            Assert.AreEqual(4, s.Column);
        }
    }
}
