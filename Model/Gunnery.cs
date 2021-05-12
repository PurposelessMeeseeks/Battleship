using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Linear,
        Surrounding,
        Random
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, List<int> shipLengths)
        {
            EvidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(sl => sl);
            ShipsToShoot = sorted.ToList();
            TargetSelect = new RandomShooting(EvidenceGrid, ShipsToShoot[0]);
        }
        public Square NextTarget()
        {
            Square lastTarget = TargetSelect.NextTarget();
            return lastTarget;
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidenceGrid.RecordResult();
                        
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {

            if (result == HitResult.Hit)
            {
                lastHits.Add(lastTarget);

                if (ShootingTactics == ShootingTactics.Random)
                {
                    TargetSelect = new SurroundingShooting(EvidenceGrid, lastHits[0]);
                    ShootingTactics = ShootingTactics.Surrounding;
                }
                else if (ShootingTactics == ShootingTactics.Surrounding)
                {
                    TargetSelect = new LinearShooting(EvidenceGrid, lastHits);
                    ShootingTactics = ShootingTactics.Linear;
                }
            }

            if (result == HitResult.Sunken)
            {
                TargetSelect = new RandomShooting(EvidenceGrid, ShipsToShoot[0]);
                ShootingTactics = ShootingTactics.Random;
            }
        }

        public ShootingTactics CurrentShootingTactics
        {
            get { return ShootingTactics; }
        }

        private Grid EvidenceGrid;
        private List<int> ShipsToShoot;
        private Square lastTarget;
        private List<Square> lastHits;
        private ITargetSelect TargetSelect;
        private ShootingTactics ShootingTactics = ShootingTactics.Random;
    }
}
