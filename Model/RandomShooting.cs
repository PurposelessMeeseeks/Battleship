using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        private Grid Grid;
        private int ShipLength;
        private Random random;

        public RandomShooting(Grid evidenceGrid, int shipLength)
        {
            Grid = evidenceGrid;
            ShipLength = shipLength;
        }

        public Square NextTarget()
        {

            var allPlacements = Grid.GetAvailablePlacements(ShipLength);
            // create a simple array of all squares
            var allCandidates = allPlacements.SelectMany(item => item);
            // create groups with individual squares
            var groups = allCandidates.GroupBy(item => item);
            // find the number of squares in the largest group
            var maxCount = groups.Max(item => item.Count());
            // filter groups with count == maxCount
            var largestGroups = groups.Where(item => item.Count() == maxCount);
            // fetch keys from largestGroups
            var mostCommonSquares = largestGroups.Select(item => item.Key);

            if (mostCommonSquares.Count() == 1) 
            {
                mostCommonSquares.First();
            }

            int index = random.Next(mostCommonSquares.Count());
            return mostCommonSquares.ElementAt(index);


            //select one of the squares using random
            // calculate how many times each square appears in allPlacements - from IEnumerable<IEnumerable<Square>>
            allPlacements.Count();

            throw new NotImplementedException();
        }
    }
}
