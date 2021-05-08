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
            var sorted = shipLengths.OrderByDescending(s1 => s1);
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidenceGrid.RecorrdResult(); 

            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            // evidanceGrid.RecordResult();

            // if result is Missed dont change the tactics
            // if result is Hit:
            //      -if current tactics is Random, change it to Surrounding and:
            //      targetSelect = new SurroundingShooting(...);
            //      -if current tactics is Surrounding, change it to Linear and:
            //      targetSelect = new LinearShooting(...);
            //      -if current tactics is Linear, dont change it
            //      -if result is Sunken, change current tactics to Random and:
            //      target = new RandomShooting
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
