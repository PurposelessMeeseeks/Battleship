using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactis
    {
        Linear,
        Random,
        Sorrounding
    }

    public class Gunnery
    {

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToShoot = shipLengths.ToList();

            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public ShootingTactis CurrentShootingTactis { get { return shootingTactis; } }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGrid.RecordResult()
            // evidenceGrid.RecordResult();
            
            InvalidateTacticsState(result);
        }


        private void InvalidateTacticsState(HitResult result)
        {
            // if result is Missed dib0t change tactics (/)
            // if result is HIT: (/)
            //      - if current tactics is random, change it to sorrounding 
            //      - else if tactics is sorrounding change it to linear
            //      - if current tactis is linear, dont change it
            // if result is sunken
            //      go to random

            if (result == HitResult.Sunken)
            {
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
                shootingTactis = ShootingTactis.Random;
            }

            if (result == HitResult.Hit)
            {
                if (shootingTactis == ShootingTactis.Random)
                {
                    targetSelect = new SorroundingShooting(evidenceGrid, shipsToShoot);
                    shootingTactis = ShootingTactis.Sorrounding;
                }
                else if (shootingTactis == ShootingTactis.Sorrounding)
                {
                    targetSelect = new LinearShooting(evidenceGrid, shipsToShoot);
                    shootingTactis = ShootingTactis.Linear;
                }
            }
        }

        private Grid evidenceGrid;
        private List<int> shipsToShoot;
        private ShootingTactis shootingTactis = ShootingTactis.Random;
        private ITargetSelect targetSelect;
    }
}
