using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        public SurroundingShooting(Grid grid, Square FirstHit, int shipLenght)
        {
            this.grid = grid;
            this.firstHit = firstHit;
            this.shipLenght = shipLenght;
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            var up = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwords);
            var right = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rightwords);
            var down = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwords);
            var left = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwords);

            if (up.Count() > 0)
            {
                squares.Add(up);
            }

            if (right.Count() > 0)
            {
                squares.Add(right);
            }

            if (down.Count() > 0)
            {
                squares.Add(down);
            }

            if (left.Count() > 0)
            {
                squares.Add(left);
            }

            var sorted = squares.OrderByDescending(seq => seq.Count());
            int maxLenght = sorted.ElementAt(0).Count();

            if (maxLenght > shipLenght - 1)
            {
                maxLenght = shipLenght - 1;
            }

            var longest = sorted.Where(seq => seq.Count() >= maxLenght);

            if (longest.Count() == 1)
            {
                return longest.ElementAt(0).First();
            }

            int index = random.Next(longest.Count());

            return longest.ElementAt(index).First();

            // TODO: do it in a similar way as for surrounding shooting
        }

        private Grid grid;
        private int shipLenght;
        private Square firstHit;
        private Random random = new Random();
    }
}