﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    class SurroundingSquaresEliminator : ISquareEliminator
    {
        public SurroundingSquaresEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }
        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            //prode kroz shipsquares, uzme stupac prvog i zadnjeg polja da determinira jeli horizontalan ili vertikalan
            throw new NotImplementedException();
        }
        private readonly int rows;
        private readonly int columns;
    }
}
