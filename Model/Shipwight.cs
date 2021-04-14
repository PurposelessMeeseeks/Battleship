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
            for (int retries = 5 - 1; retries >= 0; --retries)
            {
                Queue<int> lenghts = new Queue<int>(shipLenghts);
                Grid grid = new Grid(rows, columns);
                Fleet fleet = new Fleet();
                while (lenghts.Count > 0)
                {
                    int lenght = lenghts.Dequeue();
                    var placements = grid.GetAvailablePlacements(lenght);
                    if (placements.Count() == 0)
                        return null;
                    int index = random.Next(placements.Count());
                    var selected = placements.ElementAt(index);
                    fleet.CreateShip(selected);
                    grid.Eliminate(selected);

                }
                return fleet;
            }
            throw new ArgumentException();
            

            
        }

        private Grid grid;
        private Fleet fleet;
        
        
        private int rows;
        private int columns;
        private IEnumerable<int> shipLenghts;
        private Random random = new Random();
    }
}
