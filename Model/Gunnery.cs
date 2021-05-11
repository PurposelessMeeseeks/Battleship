using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Gunnery
    {   

        enum ShootingTactics
        {
            Random,
            Surrounding,
            Linear
        }
        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            evidanceGrid = new Grid(rows, columns);
            var sorted = shipLenghts.OrderByDescending(sl => sl);
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidanceGrid, shipsToShoot);
        }

        public Square NextTarger()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {

            throw new NotImplementedException();
        }

        public ShootingTactics ShootingTactics
        {
            get { return shootingTactics; }
        }

        private Grid evidanceGrid;
        private List<int> shipsToShoot;
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
