﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public class LinearShooting : ITargetSelect
    {
        public LinearShooting(Grid evidenceGrid, List<Square> squaresHit, int shipLength)
        {
            this.grid = evidenceGrid;
            this.squaresHit = squaresHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var sorted = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Column));

            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    var left = grid.GetAvailablePlacementsInDirection(sorted.First(), Grid.Direction.Leftwards);

                    if (left.Count() > 0)
                    {
                        squares.Add(left);
                    }

                    var right = grid.GetAvailablePlacementsInDirection(sorted.Last(), Grid.Direction.Rightwards);

                    if (right.Count() > 0)
                    {
                        squares.Add(right);
                    }
                    break;

                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(sorted.First(), Grid.Direction.Upwards);

                    if (up.Count() > 0)
                    {
                        squares.Add(up);
                    }

                    var down = grid.GetAvailablePlacementsInDirection(sorted.Last(), Grid.Direction.Downwards);

                    if (down.Count() > 0)
                    {
                        squares.Add(down);
                    }
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            var sorted_2 = squares.OrderByDescending(seq => seq.Count());

            int maxLength = sorted_2.ElementAt(0).Count();

            if (maxLength > shipLength - squaresHit.Count())
            {
                maxLength = shipLength - squaresHit.Count();
            }

            var longest = sorted_2.Where(seq => seq.Count() >= maxLength);

            if (longest.Count() == 1)
            {
                return longest.ElementAt(0).First();
            }

            int index = random.Next(longest.Count());

            return longest.ElementAt(index).First();
        }

        private Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
            {
                return Orientation.Horizontal;
            }

            return Orientation.Vertical;
        }

        private readonly Grid grid;
        private readonly List<Square> squaresHit;
        private readonly Random random = new Random();
        private readonly int shipLength;
    }
}
