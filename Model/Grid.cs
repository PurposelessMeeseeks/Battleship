﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {
        public Grid(int rows, int columns)
        {
            this.rows    = rows;
            this.columns = columns;

            squares = new Square?[rows, columns];

            for(int r = 0;  r < rows; ++r)
            {
                for (int c = 0; c < columns; ++c)
                {
                    squares[r,c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            List<List<Square>> result = GetHorizontalPlacements(length);
            // TODO: Homeworks, add vertical placements
            return result;
        }

        private List<List<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<List<Square>>();

            for (int r = 0; r < rows; ++r)
            {
                var gathered = new LimitedQueue<Square>(length);

                for (int c = 0; c < columns; ++c)
                {
                    if (squares[r, c] != null)
                    {
                        gathered.Enqueue(squares[r, c].Value);
                    }
                    else 
                    {
                        gathered.Clear();
                    }

                    if (gathered.Count == length)
                    {
                        result.Add(new List<Square>(gathered.ToArray()));
                    }
                }
            }

            return result;
        }


        private IEnumerable<IEnumerable<Square>> GetVerticalPlacements(int length)
        {
            return new List<List<Square>>();
        }


        private int rows;
        private int columns;

        private Square?[,] squares;
    }
}
