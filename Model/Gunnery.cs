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

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGrid.RecordResult(); 

            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            switch (result)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    switch (shootingTactics)
                    {
                        case ShootingTactics.Random:
                            shootingTactics = ShootingTactics.Surrounding;
                            targetSelect = new SurroundingShooting(evidenceGrid, new Square(1, 1));
                            return;
                        case ShootingTactics.Surrounding:
                            shootingTactics = ShootingTactics.Linear;
                            targetSelect = new LinearShooting(evidenceGrid, new List<Square>{ new Square(1, 1) });
                            return;
                        case ShootingTactics.Linear:
                            return;
                    }
                    break;
                case HitResult.Sunken:
                    shootingTactics = ShootingTactics.Random;
                    targetSelect = new RandomShooting(evidenceGrid, 4);
                    return;
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
