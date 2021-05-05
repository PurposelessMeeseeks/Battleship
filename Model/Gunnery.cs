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
        public Gunnery(int rows,int columns,IEnumerable<int> shipLengths)
        {
            evidenceGrid = new Grid(rows, columns);
            var sorted = shipLengths.OrderByDescending(sl => sl);
            shipsToshoot = sorted.ToList() ;
            targetSelect = new RandomShooting(evidenceGrid,shipsToshoot[0]);

        }

        public Square NextTarget()
        {
            return targetSelect.NextTarget();
        }

        public void RecordShootingResult(HitResult result)
        {
            //evidenceGrid.RecorrdResult(); 

            ChangeTactics(result);
            throw new NotImplementedException();
        }
        private void ChangeTactics(HitResult result)
        {
            //if result is Missed dont change the tactics
            //if result is Hit:
            //  if current tactics is random,change it to surroudinga and:
            //  targetSelect = new SurroudingShooting(..);
            //  if current tactics is surrouding , change it to linear and
            //  targetSelect = new LinearShooting(..);
            //  if current tactics is linear,dont change it 
            //if result is sunken , change current tactics to random and
            //   //  target=new RandomShooting();
        }
        public ShootingTactics ShootingTactics
        {
            get { return shootingTactics; }
        }

        private  Grid evidenceGrid;
        private List<int> shipsToshoot;
        private ITargetSelect targetSelect;
        private ShootingTactics shootingTactics = ShootingTactics.Random;
    }
}
