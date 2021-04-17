﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SorroundingSquaresEliminator : ISquareEliminator
    {
        public SorroundingSquaresEliminator(int rows, int columns)
        {
            this.rows    = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> squares)
        {
            var mostLeftShip  = squares.First();
            var mostRightShip = squares.Last();

            // get the sorrounding squares dimension on the most left ship
            int left = mostLeftShip.column > 0 ? mostLeftShip.column - 1 : mostLeftShip.column;
            int top = mostLeftShip.row > 0 ? mostLeftShip.row - 1 : mostLeftShip.row;

            // get the sorrounding squares dimension on the most right ship
            int right = mostRightShip.column + 1;
            right = (right < columns) ? ++right : right;

            int bottom = mostRightShip.row + 1;
            bottom = (bottom < rows) ? ++bottom : bottom;

            var toEliminate = new List<Square>();

            for (int r = top; r < bottom; ++r)
            {
                for (int c = left; c <right; ++c)
                {
                    toEliminate.Add(new Square(r, c));
                }
            }

            return toEliminate;
        }

        private readonly int rows;
        private readonly int columns;
    }
}
