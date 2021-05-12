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
            var sorted = shipLengths.OrderByDescending(sl => sl).ToArray();
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
        }

        public Square NextTarget()
        {
            LastTarget = targetSelect.NextTarget();
            return LastTarget;
        }

        public void RecordShooting(HitResult result)
        {
            //evidenceGrid.RecordResult();
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
                lastHits.Add(LastTarget);
                targetSelect = new SurroundingShooting(evidenceGrid, lastHits[0]);
                shootingTactics = ShootingTactics.Surrounding;
            }
            else if (HitResult.Missed == result && ShootingTactics == ShootingTactics.Surrounding)
            {
                targetSelect = new SurroundingShooting(evidenceGrid, lastHits[0]);
                shootingTactics = ShootingTactics.Surrounding;
            }
            else if(HitResult.Hit == result && ShootingTactics == ShootingTactics.Surrounding)
            {
                lastHits.Add(LastTarget);
                targetSelect = new LinearShooting(evidenceGrid, lastHits);
                shootingTactics = ShootingTactics.Linear;
            }
            else if(HitResult.Missed == result && ShootingTactics == ShootingTactics.Linear)
            {
                targetSelect = new LinearShooting(evidenceGrid, lastHits);
                shootingTactics = ShootingTactics.Linear;
            }
            else if(HitResult.Sunken == result && ShootingTactics == ShootingTactics.Linear)
            {
                int sunkenShipLength = lastHits.Count;
                shipsToShoot.Remove(sunkenShipLength);
                lastHits.Clear();
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
                shootingTactics = ShootingTactics.Random;
            }

            // if result is missed stay in random shooting tactic
            // else if hit then surrounding shooting targetSelect = new SurroundingShooting(itd, itd);
            // if hit then linear shooting targetSelect = new LinearShooting(...);, otherwise stay in surrounding
            // if result is sunken, change back to random shooting targetSelect = new RandomShooting(...);
        }

        public ShootingTactics ShootingTactics
        {
            get { return shootingTactics; }
        }

        private Grid evidenceGrid;
        private List<int> shipsToShoot;
        private Square LastTarget;
        private List<Square> lastHits = new List<Square> { };
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
