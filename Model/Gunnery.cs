using System;
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
            shipsToShoot = shipLengths.ToList();
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGrid.RecordResult();

            ChangeTActics(result);
        }

        private void ChangeTActics(HitResult result)
        {
            if (result == HitResult.Hit)
            {
                if (ShootingTactics == ShootingTactics.Random)
                {
                    targetSelect = new SurroundingShooting(evidenceGrid, shipsToShoot);
                    shootingTactics = ShootingTactics.Surrounding;
                }
                else if (ShootingTactics == ShootingTactics.Surrounding)
                {
                    targetSelect = new LinearShooting(evidenceGrid, shipsToShoot);
                    shootingTactics = ShootingTactics.Linear;
                }
            }

            if (result == HitResult.Sunken)
            {
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
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
