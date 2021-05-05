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
        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            evidencesGrid = new Grid(rows, columns);
            var sorted = shipLenghts.OrderByDescending(sl => sl);
            shipsToShoot = sorted.ToList();
            targetSelect = new RandomShooting(evidencesGrid, shipsToShoot[0]);
        }

        public Square NextTarget()
        {

            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidenceGrid.RecordResult();

            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            // if result is Missed dont change the tactiscs
            // if result is Hit 
            //      -if current tactis is Random change it to Surrounding
            //      targetSelect = new Surounding(..)
            //      -if current tactis is Surr, change it to Linear
            //      targetSelect = new LinerShooting
            //      -if current tactics is Linear, dont change it
            // if result is Sunken, change current tactics to Random
            //   target = new RandomShooting();
        }

        public ShootingTactics CurrentShootingTactics
        {
            get { return shootingTactics; }
        }


        private Grid evidencesGrid;
        private List<int> shipsToShoot;
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;

    }
}
