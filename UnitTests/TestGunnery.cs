using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGunnery
    {
        [TestMethod]
        public void InitiallyShootingTacticsIsRandom()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsRandomForSquareMissed()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromRandomToSurroundingWhenFirstSquareIsHit()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit;
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromRandomToSurroundingWhenFirstSquareIsHit()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit;
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }
    }
}
