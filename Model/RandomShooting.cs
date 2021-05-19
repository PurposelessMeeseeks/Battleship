using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLength);
            //create simple array of all squares
            var allCandidates = allPlacements.SelectMany(seq => seq);
            // create groups with individual squares
            var groups = allCandidates.GroupBy(sq => sq);
            // find number of quares in the largest group
            var maxCount = groups.Max(g => g.Count());
            // filter groups with count == maxCount
            var largestGroups = groups.Where(g => g.Count() == maxCount);
            // fetch keys from largestGroups
            var mostCommonSquares = largestGroups.Select(g => g.Key);
            if (mostCommonSquares.Count() == 1)
                mostCommonSquares.First();
            int index = random.Next(mostCommonSquares.Count());
            return mostCommonSquares.ElementAt(index);
            // TODO: select one of squares using random:
            // 1. calculaate how many times each sqaure in allPlacements
            // 2. find squares whic appear most often
            // 3.from these squares select randomly one as target
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
        private Random random = new Random();
    }
}
