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
        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLenghts.OrderByDescending(sl => sl);
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGrid.RecordResult();

            ChangeTactics(result);

            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            // if result is Missed dont change the tactics
            // if result is Hit:
            //      - if current tactics is Random, change it to Surrounding and:
            //        targetSelect = new SurroundingShooting(...)
            //      - if current tactics is Surrounding, change it to Linear
            //      - if current tactics is Linear dont change tactics
            // if result is Sunken, change current tactics to Random
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
