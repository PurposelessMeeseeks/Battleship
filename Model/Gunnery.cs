using System;
using System.Collections.Generic;
using System.Linq;

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
            shipsToShoot = sorted.ToList(); // TODO: bitno za zavrsni !! OrderByDescending
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
        }



        public Square NextTarget()
        {

            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGreid.Result();

            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            // if result is Missed dont change the tactics
            // if result is hit:
            //      - if current tactics is Random, chnage it to Surrounding and:
            //      targetSelect = new SurroundingShooting(...);
            //      - if current tactics is Surrounding, change it to linear and:
            //      targetSelect = new LinearShooting(...);
            //      - if current tactics is Linear, dont change it
            // if result is Sunken, change current tactics to Random and:
            //      target = new RandomShooting();
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
