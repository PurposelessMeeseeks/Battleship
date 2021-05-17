using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model {
    public enum ShootingTactics {
        Random, Surrounding, Linear
    }

    public class Gunnery {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts) {
            var Sorted = shipLenghts.OrderByDescending(sl => sl).ToArray();

            EvidenceGrid = new Grid(rows, columns);
            ShipsToShoot = Sorted.ToList();
            TargetSelect = new RandomShooting(EvidenceGrid, ShipsToShoot);
        }

        public Square NextTarget() {
            return TargetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result) {
            //evidanceGrid.RecordResult()

            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result) {
            switch (result) {
                case HitResult.Missed:
                    return;

                case HitResult.Hit:
                    switch (shootingTactics) {
                        case ShootingTactics.Random:
                            shootingTactics = ShootingTactics.Surrounding;
                            TargetSelect = new SurroundingShooting(EvidenceGrid, ShipsToShoot);
                            return;

                        case ShootingTactics.Surrounding:
                            shootingTactics = ShootingTactics.Linear;
                            TargetSelect = new LinearShooting(EvidenceGrid, ShipsToShoot);
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
                    return;

                default:
                    break;
            }
        }

        public ShootingTactics ShootingTactics { get { return shootingTactics; } }

        private Grid EvidenceGrid;
        private List<int> ShipsToShoot;
        private ITargetSelect TargetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}