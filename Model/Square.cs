using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public struct Square
    {
        public Square(int Row, int Column)
        {
            row = Row;
            column = Column;
        }

        public readonly int row;
        public readonly int column;
    }
}
