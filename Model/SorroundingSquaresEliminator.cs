using System;
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
            // naci namjanji redak i namjanji stupac - umanjis 1
            // naci najveci redat i najveci stupac uvecas za 1
            // for loop i kreirati square result i insertati squarese

            throw new NotImplementedException();
        }

        private readonly int rows;
        private readonly int columns;
    }
}
