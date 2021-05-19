﻿using System;
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
        public Gunnery(int rows,int columns,IEnumerable<int> shipLengths)
        {
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(sl => sl);
            shipsToshoot = sorted.ToList() ;
            targetSelect = new RandomShooting(evidenceGrid,shipsToshoot[0]);

        }

        public Square NextTarget()
        {
            var lastTarget= targetSelect.NextTarget();
            return lastTarget;
        }

        public void RecordShootingResult(HitResult result)
        {
            evidenceGrid.RecordResult(lastTarget,result);
            if (result == HitResult.Missed)
                return;
            lastHits.Add(lastTarget);
            
            if(result==HitResult.Sunken)
            {
                //mark all squares around last hit as missed
                //mark -II- in last hit as sunken 
            }
            ChangeTactics(result);
        }
        private void ChangeTactics(HitResult result)
        {
            switch (result)
            {
                case HitResult.Hit:
                    switch (shootingTactics)
                    {
                        case ShootingTactics.Random:
                            shootingTactics = ShootingTactics.Surrounding;
                            Debug.Assert(lastHits.Count == 1);
                            targetSelect = new SurroundingShooting(evidenceGrid, lastHits[0]);
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
                    int sunkenShipLenght = lastHits.Count;
                    shipsToshoot.Remove(sunkenShipLenght);
                    lastHits.Clear();
                    targetSelect = new RandomShooting(evidenceGrid, shipsToshoot[0]);
                    return;
            }
        }
        public ShootingTactics ShootingTactics
        {
            get { return shootingTactics; }
        }

        private  Grid evidenceGrid;
        private List<int> shipsToshoot;
        private Square lastTarget;
        private List<Square> lastHits = new List<Square>();
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
