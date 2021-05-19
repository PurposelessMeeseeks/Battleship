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
        public LinearShooting(Grid evidenceGrid, List<Square> squaresHit, int shipLenght)
        {
            this.grid = evidenceGrid;
            this.squaresHit = squaresHit;
            this.shipLenght = shipLenght;
        }

        public Square NextTarget()
        {
            var sorted = new List<Square>(squaresHit.OrderBy(s => s.row + s.column));

            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    var left = grid.GetAvailablePlacementsInDirection(sorted.First(), Direction.Leftwords);

                    if (left.Count() > 0)
                    {
                        squares.Add(left);
                    }

                    var right = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Rightwords);

                    if (right.Count() > 0)
                    {
                        squares.Add(right);
                    }
                    break;

                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(sorted.First(), Direction.Upwords);

                    if (up.Count() > 0)
                    {
                        squares.Add(up);
                    }

                    var down = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Downwords);

                    if (down.Count() > 0)
                    {
                        squares.Add(down);
                    }
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            if (squares.Count > 1)
            {
                return squares[random.Next(0, 2)].First();
            }

            return squares[0].First();

            // TODO 6: select one of them optionally using random generator
        }

        private Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].row == squaresHit[1].row)
            {
                return Orientation.Horizontal;
            }

            return Orientation.Vertical;
        }

        private Grid grid;
        private List<Square> squaresHit;
        private Random random = new Random();
        private int shipLenght;
    }
}