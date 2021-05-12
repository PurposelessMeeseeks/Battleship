using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Random, Surrounding, Linear
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            var Sorted = shipLenghts.OrderByDescending(sl => sl).ToArray();

            EvidenceGrid = new Grid(rows, columns);
            ShipsToShoot = Sorted.ToList();
            TargetSelect = new RandomShooting(EvidenceGrid, ShipsToShoot);
        }

        public Square NextTarget()
        {
            var lastTarget= TargetSelect.NextTarget();
            return lastTarget;
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidanceGrid.RecordResult()

            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            switch (result)
            {
                case HitResult.Missed:
                    return;

                case HitResult.Hit:
                    lastHits.Add(lastTarget);
                    switch (shootingTactics)
                    {
                        case ShootingTactics.Random:
                            shootingTactics = ShootingTactics.Surrounding;
                            Debug.Assert(lastHits.Count == 1);
                            TargetSelect = new SurroundingShooting(EvidenceGrid, lastHits[0]);
                            return;

                        case ShootingTactics.Surrounding:
                            shootingTactics = ShootingTactics.Linear;
                            TargetSelect = new LinearShooting(EvidenceGrid, lastHits);
                            return;

                        case ShootingTactics.Linear:
                            TargetSelect = new RandomShooting(EvidenceGrid, ShipsToShoot[0]);
                            return;

                        default:
                            break;
                    }
                    break;

                case HitResult.Sunken:
                    shootingTactics = ShootingTactics.Random;
                    int sunkenShipLength = lastHits.Count;
                    ShipsToShoot.Remove(sunkenShipLength);
                    lastHits.Clear();
                    TargetSelect = new RandomShooting(EvidenceGrid, 4);
                    return;

                default:
                    break;
            }
        }

        public ShootingTactics ShootingTactics { get { return shootingTactics; } }

        private Grid EvidenceGrid;
        private List<int> ShipsToShoot;
        private List<Square> lastHits= new List<Square>();
        private Square lastTarget;
        private ITargetSelect TargetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}