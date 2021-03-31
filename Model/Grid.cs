using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model {
    public class Grid {

        public Grid(int rows, int columns) {

            this.rows = rows;
            this.columns = columns;
            squares = new Square?[rows, columns];

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < columns; c++) {
                    squares[r, c] = new Square(r, c);
                }

            }
        }

        private int rows;
        private int columns;

        private Square?[,] squares;


        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length) {

            List<List<Square>> res = GetHorizontalPlacements(length);

            //res.Add(getVerticalPlacements(length));
            return res;
        }


        private List<List<Square>>  GetHorizontalPlacements(int length) {
            var res = new List<List<Square>>();


            for (int r = 0; r < rows; r++) {

                //int available = 0;
                LimitedQueue<Square> gather = new LimitedQueue<Square>(length);

                for (int c = 0; c < columns; c++) {

                    if (squares[r, c] != null) {
                        gather.Enqueue(squares[r, c].Value);
                        //available++;
                    } else {
                        //available = 0;
                        gather.Clear();
                    }


                    if (gather.Count >= length) {
                        res.Add(new List<Square>(gather.ToArray<Square>()));
                    }
                }
            }

            return res;

        }

        //TODO getVerticalplacements
         private List<List<Square>> getVerticalPlacements(int length) {

            var res = new List<List<Square>>();


            return res;

        }



    }
}
