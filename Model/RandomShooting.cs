using System;
using System.Linq;

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
            // vraća nizove nizova
            var allPlacements = grid.GetAvailablePlacements(shipLength);
            // create simple array of all squares
            var allCandidates= allPlacements.SelectMany(seq => seq);
            // create geoups with individual squares
            var groups = allCandidates.GroupBy(sq => sq);
            // find naumber of squares in the largest
            var maxCount = groups.Max(g => g.Count());
            // filter groups with count == maxCount
            var largestGroups = groups.Where(g => g.Count() == maxCount);
            // fetch keys from largestGroups
            var mostComomnSquares = largestGroups.Select(g => g.Key);
            if (mostComomnSquares.Count() == 1)
                mostComomnSquares.First();
            int index = random.Next(mostComomnSquares.Count());
            return mostComomnSquares.ElementAt(index);

            // TODO: DZ select one of squares using random
            // 1. calculate how many times each square appears in allPlacements (IEnumerable<IEnumerable<Square>>)
            // 2. find squares which appear most often
            // 3. from these squares select randomly one as target

            throw new NotImplementedException();
        }

        private Grid grid;



        private int shipLength;
        private Random random = new Random();
    }
}
