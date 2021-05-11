using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void SquareConstructorCreateASquareATGivenRowAndColumn()
        {
            Square s = new Square(5, 4);
            Assert.AreEqual(5, s.Row);
            Assert.AreEqual(4, s.Column);
        }

        [TestMethod]
        public void SetSquareStateChangesSquareStateToMissedForHiResultMissed()
        {
            Square s = new Square(5, 4);
            Assert.AreEqual(SquareState.Default, s.SquareState);
            s.SetSquareState(HitResult.Missed);
            Assert.AreEqual(SquareState.Missed, s.SquareState);
        }
        [TestMethod]
        public void SetSquareStateChangesSquareStateToHitForHiResultHit()
        {
            Square s = new Square(5, 4);
            Assert.AreEqual(SquareState.Default, s.SquareState);
            s.SetSquareState(HitResult.Hit);
            Assert.AreEqual(SquareState.Hit, s.SquareState);
        }
        [TestMethod]
        public void SetSquareStateChangesSquareStateToSunkenForHiResultSunken()
        {
            Square s = new Square(5, 4);
            Assert.AreEqual(SquareState.Default, s.SquareState);
            s.SetSquareState(HitResult.Sunken);
            Assert.AreEqual(SquareState.Sunken, s.SquareState);
        }
    }
}
