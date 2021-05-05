using System;
using System.Collections.Generic;
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
            return TargetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidanceGrid.RecordResult()

            ChangeTactics(result);
            throw new NotImplementedException();
        }

        private void ChangeTactics(HitResult result)
        {
            //if result is Missed don't change the tactics
            //if result is Hit:
            //if current tactics is Random, change it to Surrounding and:
            //targetSelect=new urroundingShooting(...)

            //if current tactics is Surrounding, change it to Linear and:
            //targetSelect=new LinearShooting(...)

            //if curent tatics is Linear, don't change it
            //targetSelect=new RandomShooting(...)

            //if result is Sunken, change current tactics to Random
        }

        public ShootingTactics ShootingTactics { get { return shootingTactics; } }

        private readonly Grid EvidenceGrid;
        private readonly List<int> ShipsToShoot;
        private readonly ITargetSelect TargetSelect;
        private readonly ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}