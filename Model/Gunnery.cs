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
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToSink = new List<int>(sorted);
            evidenceGrid = new Grid(rows, columns);
            selectTarget = new RandomShooting();
        }

        public Square NextTarget()
        {
            return selectTarget.NextTarget();
        }

        public void ProcessShootingResult(HitResult result)
        {
            // Mark the result in evidence grid
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            switch (result)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    if (currentTactics == ShootingTactics.Random)
                    {
                        selectTarget = new SurroundingShooting();
                        currentTactics = ShootingTactics.Surrounding;
                        return;
                    }
                    if (currentTactics == ShootingTactics.Surrounding)
                    {
                        selectTarget = new LinearShooting();
                        currentTactics = ShootingTactics.Linear;
                        return;
                    }
                    break;
                case HitResult.Sunken:
                    selectTarget = new RandomShooting();
                    currentTactics = ShootingTactics.Random;
                    break;
            }
        }

        public ShootingTactics CurrentTactics
        {
            get { return currentTactics; }
        }

        private Grid evidenceGrid;
        private List<int> shipsToSink;
        private ISelectTarget selectTarget;
        private ShootingTactics currentTactics = ShootingTactics.Random;
    }
}
