﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class OnlyShipSquaresEliminator : ISquareEliminator
    {
        public IEnumerable<Square> ToEliminate(IEnumerable<Square> squares)
        {
            return squares;
        }
    }
}
