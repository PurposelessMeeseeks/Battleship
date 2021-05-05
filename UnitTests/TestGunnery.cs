using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTest
{
    [TestClass]
    public class TestGunnery
    {
        [TestMethod]
        public void InitiallyShootingTacticsIsRandom()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(ShootingTactics.Random, g.CurrentShootingTactics);

        }


        [TestMethod]
        public void ShootingTacticsRemainsRandomForSquareMissed()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, g.CurrentShootingTactics);

        }


        [TestMethod]
        public void ShootingTacticsChangesFromRandomToSurroundingWhenFirstSquareIsHit()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentShootingTactics);

        }

        [TestMethod]
        public void ShootingTacticsRemainsSurroundingWhenFirstSquareIsMissed()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentShootingTactics);

            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentShootingTactics);

        }


        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToLinearAfterSeondSquareIsHit()
        {
            Gunnery g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.RecordShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentShootingTactics);
            //??
            g.RecordShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentShootingTactics);

        }

        //jos jedna
    }
}
