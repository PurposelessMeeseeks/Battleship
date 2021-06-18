using System;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        private readonly Grid Grid;
        private readonly int ShipLenght;

        //private readonly Grid evidenceGrid;
        //private readonly List<int> shipsToShoot;
        private readonly Random random = new Random();

        public RandomShooting(Grid grid, int shipLenght)
        {
            Grid = grid;
            ShipLenght = shipLenght;
        }

        public Square NextTarget()
        {
            var allPlacements = Grid.GetAvailablePlacements(ShipLenght);

            // create simple array of all squares
            var allCandidates = allPlacements.SelectMany(seq => seq);
            //Debug.Assert(allPlacements.Count() != 0);

            // create groups with individual squares
            var groups = allCandidates.GroupBy(sq => sq);

            // find number of squares in the largest group
            //var maxCount = groups.DefaultIfEmpty().Max(g => g.Count()iu
            var maxCount = groups.Max(g => g.Count());

            // filter groups with count == maxCount
            var largestGroups = groups.Where(g => g.Count() == maxCount);

            // fetch keys from largestGroups
            var mostCommunSquares = largestGroups.Select(g => g.Key);

            if (mostCommunSquares.Count() == 1)
            {
                mostCommunSquares.First();
            }

            int index = random.Next(0, mostCommunSquares.Count());

            return mostCommunSquares.ElementAt(index);
        }
    }
}