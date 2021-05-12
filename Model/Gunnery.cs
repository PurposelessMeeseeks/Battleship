﻿using System;
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

            lastTarget = targetSelect.NextTarget();
            return lastTarget;
        }

        public void RecordShootingResult(HitResult result)
        {
            // evidenceGrid.RecordResult();

            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            // if result is Missed, stay in Random tactics
            // if result is Hit:
            //      - if current tactics is Random, change it to Surrounding and:
            //        targetSelect = new SurroundingShooting(Grid, firstHit);
            //      - if current tactics is Surrounding, change it to Linear and:
            //        targetSelect = new LinearShooting(Grid, firstHit);
            //      - if current tactics is Linear, stay in Linear tactics
            //if result is Sunken, change current tactics to Random and:
            //  target = new RandomShooting();
            throw new NotImplementedException();
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
