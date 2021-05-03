using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Shipwright
    {
        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.rows = rows;
            this.columns = columns;
            this.shipLengths = shipLengths;
        }

        public Fleet CreateFleet()
        {
            Grid grid = new Grid(rows, columns);
            Fleet fleet = new Fleet();
            var sortedLengths = shipLengths.OrderByDescending(l => l);
            Queue<int> lengths = new Queue<int>(sortedLengths);
            while (lengths.Count > 0)
            {
                int len = lengths.Dequeue();
                var placements = grid.GetSequences(len);
                var index = random.Next(placements.Count());
                var selected = placements.ElementAt(index);
                fleet.CreateShip(selected);
                // TODO: expand selection to surrounding squares
                grid.RemoveSquares(selected);
            }
            return fleet;
        }

        private readonly int rows;
        private readonly int columns;
        private readonly IEnumerable<int> shipLengths;
        private Random random = new Random();
    }
}
