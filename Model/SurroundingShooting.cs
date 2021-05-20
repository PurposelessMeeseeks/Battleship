using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        public SurroundingShooting(Grid grid, Square firstHit, shipLength)
        {
            this.grid = grid;
            this.firstHit = firstHit;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {

            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            var up = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwards);
            if (up.Count() > 0)
                squares.Add(up);
            var right = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rigrhwards);
            if (right.Count() > 0)
                squares.Add(right);
            var down = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwards);
            if (right.Count() > 0)
                squares.Add(right);
            var left= grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwards);
            if (right.Count() > 0)
                squares.Add(right);

            var sorted = squares.OrderByDescending(seq => seq.Count());
            int maxLength = sorted.ElementAt(0).Count();
            if (maxLength > shipLength - 1)
                maxLength = shipLength - 1);
            var longest = sorted.Where(seq => seq.Count() >= maxLength);
            if (longest.Count() == 1)
                return longest.ElementAt(0).First();
            int index = random.Next(longest.Count());
            return longest.ElementAt(index).First();
            
        }
        private Grid grid;
        private Square firstHit;
        private int shipLength;
        private Random random = new Random();
    }
}
