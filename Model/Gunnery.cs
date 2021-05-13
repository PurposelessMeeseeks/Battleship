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
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
        }

        public Square NextTaget()
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
            // if result is Hit
            //      - if current tactics is Random, change it to Surrounding and:
            //      targetSelect = new SurroundingShooring(...);
            //      - if current tactics is Surrounding, change it to Linear and:
            //      targetSelect = new LinearShooring(...);
            //      - if current tactics is Linear, don't change it 
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
