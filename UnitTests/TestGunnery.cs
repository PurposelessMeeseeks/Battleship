using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.UnitTests
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
            g.RecordShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsReaminsSurroundigAfterSquareIsMissed()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToLinearAfterSecondSquareIsHit()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            g.RecordShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Linear, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsLinearAfterSquareIsMissed()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            g.RecordShootingResult(HitResult.Hit);
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Linear, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterShipIsSunken()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            g.RecordShootingResult(HitResult.Hit);
            g.RecordShootingResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }
    }
}
