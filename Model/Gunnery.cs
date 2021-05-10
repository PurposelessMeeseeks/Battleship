using System;
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
        public Gunnery (int rows,int columns,IEnumerable<int> shipLengths)
        {
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToSink = new List<int>(sorted);
            evidanceGrid = new Grid(rows, columns);
            selectTarget = new RandomShooting();
        }

        public Square NextTarget()
        {
            return selectTarget.NextTarget();
        }

        public void ProcessShootingResult(HitResult result)
        {
            //Mark the result in evidence grid 
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            //if result is Missed, don't change the tactics
            //if result is Hit:
            //     - if current tactic is random, change it to  Surrounding 
            //     - if current tactic is Surrounding, change it to Lienar
            //     - else keep it Linear
            //  if result is Sunken, change to Random
        }

        public ShootingTactics CurrentTactics
        {
            get { return currentTactics; }
        }

        private Grid evidanceGrid;
        private List<int> shipsToSink;
        private ISelectTarget selectTarget;
        private ShootingTactics currentTactics = ShootingTactics.Random;
    }
}
