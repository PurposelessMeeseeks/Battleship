using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var lastTarget = targetSelect.NextTarget();
            return lastTarget;
        }

        public void RecordShootingResult(HitResult result)
        {
            evidenceGrid.RecordResult(lastTarget, result);
            if (result == HitResult.Missed)
                return;
            lastHits.Add(lastTarget);
            if (result == HitResult.Sunken) 
            {

            }

            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            switch ( result)
            {
                case HitResult.Hit:                  
                    switch (shootingTactics)
                    {
                        case ShootingTactics.Random:
                            shootingTactics = ShootingTactics.Surrounding;
                            targetSelect = new SurroundingShooting(evidenceGrid, lastHits[0]);
                            Debug.Assert(lastHits.Count == 1);
                            return;
                        case ShootingTactics.Surrounding:
                            shootingTactics = ShootingTactics.Linear;
                            targetSelect = new LinearShooting(evidenceGrid, lastHits);
                            return;
                        case ShootingTactics.Linear:
                            return;
                    }
                    break;
                case HitResult.Sunken:
                    shootingTactics = ShootingTactics.Random;
                    int sunkenShipLength = lastHits.Count;
                    shipsToShoot.Remove(sunkenShipLength);
                    lastHits.Clear();
                    targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
                    return;
            }
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
        private Square lastTarget;
        private List<Square> lastHits = new List<Square>();
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
