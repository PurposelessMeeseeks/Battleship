using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid,int  shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLength);
            SortedDictionary<Square, int> SquareFrequency = new SortedDictionary<Square, int>();
            for (int i = 0; i < allPlacements.Count(); ++i)
            {
                for (int j = 0; j < allPlacements.ElementAt(i).Count(); ++j)
                {
                    if (SquareFrequency.ContainsKey(allPlacements.ElementAt(i).ElementAt(j)))
                        SquareFrequency[allPlacements.ElementAt(i).ElementAt(j)]++;
                    else
                        SquareFrequency.Add(allPlacements.ElementAt(i).ElementAt(j), 1);
                }
            }

            int max = SquareFrequency.Values.Max();
            var SquaresWithMaxApperances = SquareFrequency.Where(pair => max.Equals(pair.Value)).Select(pair => pair.Key);
            int randBroj = random.Next(0, SquaresWithMaxApperances.Count());
            return SquaresWithMaxApperances.ElementAt(randBroj); ;
        }

        private Grid grid;
        private int shipLength;
        private Random random = new Random();
    }
}
