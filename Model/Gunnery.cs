﻿using System;
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
            return TargetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            /* 
             * 
             * evidenceGrid.RecordResult();
             * 
             * if result is Missed, dont change the tactics 
             * if result is Hit:
             *      - if current tactic is Random, change it to Surrounding and:
             *          - targetSelect = new SurroundingShooting(grid, firstHit)
             *      - if current tactic is Surrounding, change it to Linear
             *          - targetSelect = new LinearShooting(grid, firstHit)
             *      - if current tactis is Linear, dont change it
             * if result is Sunken, change tactics to random and :
             *  
             *  - targetSelect = new RandomShooting(grid, firstHit)
             */
            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            /* 
             * 
             * if result is Missed, dont change the tactics 
             * if result is Hit:
             *      - if current tactic is Random, change it to Surrounding and:
             *          - targetSelect = new SurroundingShooting(grid, firstHit)
             *      - if current tactic is Surrounding, change it to Linear
             *          - targetSelect = new LinearShooting(grid, firstHit)
             *      - if current tactis is Linear, dont change it
             * if result is Sunken, change tactics to random and :
             *  
             *  - targetSelect = new RandomShooting(grid, firstHit)
             */
        }


        public ShootingTactics CurrentShootingTactics
        {
            get { return ShootingTactics; }
        }

        private Grid EvidenceGrid;
        private List<int> ShipsToShoot;
        private ITargetSelect TargetSelect;
        private ShootingTactics ShootingTactics = ShootingTactics.Random;
    }
}
