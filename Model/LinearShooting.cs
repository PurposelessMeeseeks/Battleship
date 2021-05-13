﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }
    public class LinearShooting : ITargetSelect
    {
        public LinearShooting(Grid grid, IEnumerable<Square> squaresHit)
        {
            this.grid = grid;
            this.squaresHit = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Column));
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            var orientation = GetHitSquaresOrientation();
            switch(orientation)
            {
                case Orientation.Horizontal:
                    var left = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwards);
                    if (left.Count() > 0)
                        squares.Add(left);
                    var right = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwards);
                    if (right.Count() > 0)
                        squares.Add(right);
                    break;
                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwards);
                    if (up.Count() > 0)
                        squares.Add(up);
                    var down = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwards);
                    if (down.Count() > 0)
                        squares.Add(down);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            int randBroj = random.Next(0,1);
            if (randBroj == 0)
                return squares[0].First();
            return squares[1].Last();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
                return Orientation.Horizontal;
            return Orientation.Vertical;
        }

        Grid grid;
        List<Square> squaresHit;
        Random random = new Random();
    }
}
