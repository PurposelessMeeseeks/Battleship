﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Linear
    }
    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(sl => sl);
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidenceGrid,shipsToShoot[0]);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            if (HitResult.Missed == result && ShootingTactics == ShootingTactics.Random)
            {
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
                shootingTactics = ShootingTactics.Random;
            }
            else if (HitResult.Hit == result && ShootingTactics == ShootingTactics.Random)
            {
                targetSelect = new SurroundingShooting(evidenceGrid, new Square(1, 2));
                shootingTactics = ShootingTactics.Surrounding;
            }
            else if (HitResult.Missed == result && ShootingTactics == ShootingTactics.Surrounding)
            {
                targetSelect = new SurroundingShooting(evidenceGrid, new Square(2, 3));
                shootingTactics = ShootingTactics.Surrounding;
            }
            else if (HitResult.Hit == result && ShootingTactics == ShootingTactics.Surrounding)
            {
                List<Square> squaresHit = new List<Square> { new Square(1, 2), new Square(2, 3) };
                targetSelect = new LinearShooting(evidenceGrid, squaresHit);
                shootingTactics = ShootingTactics.Linear;
            }
            else if (HitResult.Missed == result && ShootingTactics == ShootingTactics.Linear)
            {
                List<Square> squaresHit = new List<Square> { new Square(1, 2), new Square(2, 3) };
                targetSelect = new LinearShooting(evidenceGrid, squaresHit);
                shootingTactics = ShootingTactics.Linear;
            }
            else if (HitResult.Sunken == result && ShootingTactics == ShootingTactics.Linear)
            {
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[1]);
                shootingTactics = ShootingTactics.Random;
            }
        }

        public ShootingTactics ShootingTactics
        {
            get { return shootingTactics; }
        }

        private Grid evidenceGrid;
        private List<int> shipsToShoot;
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
