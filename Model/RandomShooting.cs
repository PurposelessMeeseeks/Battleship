using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ISelectTarget
    {
        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var sequences = grid.GetSequences(shipLength);
            // linearize sequences into one sequnce of arrays
            // select one of squares randomly as a target
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
        private Random random = new Random();
    }
}
