﻿using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Linear,
        Random,
        Sorrounding
    }

    public class Gunnery
    {

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            lastHits = new List<Square>();
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToShoot = shipLengths.ToList();

            targetSelect = new RandomShooting(evidenceGrid, shipsToShoot);
        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public ShootingTactis CurrentShootingTactis { get { return shootingTactis; } }

        public void RecordShootingResult(HitResult result)
        {
            evidenceGrid.RecordResult(lastTarget, result);

            if (result == HitResult.Missed)
            {
                return;
            }
            lastHits.Add(lastTarget);

            if (result == HitResult.Sunken)
            {
                SorroundingSquaresEliminator eliminator = new SorroundingSquaresEliminator(10, 10);
                eliminator.ToEliminate(lastHits);
                foreach (var item in lastHits)
                {
                    item.SetSquareState(HitResult.Sunken);
                }
            }

            InvalidateTacticsState(result);
        }


        private void InvalidateTacticsState(HitResult result)
        {
            // if result is Missed dib0t change tactics (/)
            // if result is HIT: (/)
            //      - if current tactics is random, change it to sorrounding 
            //      - else if tactics is sorrounding change it to linear
            //      - if current tactis is linear, dont change it
            // if result is sunken
            //      go to random

            if (result == HitResult.Sunken)
            {
                shootingTactis = ShootingTactis.Random;
                int sunkenShipLength = lastHits.Count;
                lastHits.Clear();
                shipsToShoot.Remove(sunkenShipLength);
                targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
            }

            if (result == HitResult.Hit)
            {
                if (shootingTactis == ShootingTactis.Random)
                {
                    // TODO: assert
                    targetSelect = new SurroundingShooting(evidenceGrid, lastHits[0], shipsToShoot[0]);
                    shootingTactis = ShootingTactis.Sorrounding;
                }
                else if (shootingTactis == ShootingTactis.Sorrounding)
                {
                    targetSelect = new LinearShooting(evidenceGrid, lastHits, shipsToShoot[0]);
                    shootingTactis = ShootingTactis.Linear;
                }
                else if (shootingTactis == ShootingTactis.Linear)
                {
                    targetSelect = new RandomShooting(evidenceGrid, shipsToShoot[0]);
                }
            }
        }

        private Grid evidenceGrid;
        private List<int> shipsToShoot;
        private Square lastTarget;
        private List<Square> lastHits;
        private ShootingTactis shootingTactis = ShootingTactis.Random;
        private ITargetSelect targetSelect;
    }
}
