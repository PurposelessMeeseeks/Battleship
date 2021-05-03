using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingSquareEliminator : ISquareEliminator
    {
        public SurroundingSquareEliminator(int rows,int columns)
        {
            this.rows = rows;
            this.columns =  columns;
        }

        private readonly int rows;
        private readonly int columns;
        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            throw new NotImplementedException();
        }
    }

   

}
