using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Shipwight
    {

        public Shipwight(int rows, int columns, IEnumerable<int> shipLenghts)
        {
               this.rows = rows;
               this.columns = columns;
               this.shipLenghts = shipLenghts.OrderByDescending(s => s);
        }

        public Fleet CreateFleet()
        {
            Queue<int> lenghts = new Queue<int>(shipLenghts);
            grid = new Grid(rows, columns);
            while(lenghts.Count > 0)
            {
                int lenght = lenghts.Dequeue();
                var placements = grid.GetAvailablePlacements(lenght);
                int index = random.Next(placements.Count());
                var selected = placements.ElementAt(index);
                fleet.CreateShip(selected);
                grid.Eliminate(selected);

            }*

            
        }

        private Grid grid;
        private Fleet fleet;
        
        
        private int rows;
        private int columns;
        private IEnumerable<int> shipLenghts;
        private Random random = new Random();
    }
}
