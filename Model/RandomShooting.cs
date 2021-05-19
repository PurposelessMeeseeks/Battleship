using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, int shipLenght)
        {
            this.grid = grid;
            this.shipLenght = shipLenght;
        }

        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLenght);
            //create simle array of all squares
            var allCandidates = allPlacements.SelectMany(seq => seq);
            // create groups with individual squares
            var groups = allCandidates.GroupBy(sq => sq);
            // find number of squares in the largest group
            var maxCount = groups.Max(g => g.Count());
            // filter groups with count == maxCount
            var largestGroups = groups.Where(g => g.Count() == maxCount);
            // fetch keys from largestGroups
            var mostCommonSquares = largestGroups.Select(g => g.Key);
            if (mostCommonSquares.Count() == 1)
                mostCommonSquares.First();
            int index = random.Next(mostCommonSquares.Count());
            return mostCommonSquares.ElementAt(index);

            //Td
            // select one of squares using random
            // calculate how many times IEnumerable<IEnumerable<Square>> calculate how many times
            //
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLenght;
        private Random random = new Random();
    }
}
