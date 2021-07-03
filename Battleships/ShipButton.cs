using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace Battleships
{
    public class ShipButton : Button
    {
        public ShipButton(int row, int column) : base()
        {
            Row = row;
            Column = column;

            int width = 35;
            int height = 35;
            int offsetX = 30;
            int offsetY = 40;

            Size = new System.Drawing.Size(width, height);
            Location = new System.Drawing.Point((width * Row) + offsetX, (height * Column) + offsetY);
            isSunken = false;

            Show();
        }

        public bool IsSunken{get {return isSunken;} }

        public void Sunk()
        {
            var currentColor = BackColor;
            Task.Run(() => SunkAnimation(Color.DarkRed, currentColor));
        }

        public void SetColor(System.Drawing.Color foreColor, System.Drawing.Color backColor)
        {
            ForeColor = foreColor;
            BackColor = backColor;
        }
        
        private void SunkAnimation(Color cOne, Color cTwo)
        {
            for (int i = 0; i < 3; ++i)
            {
                BackColor = cOne;
                Thread.Sleep(200);
                BackColor = cTwo;
                Thread.Sleep(200);
            }

            BackColor = cOne;
            isSunken = true;
        }

        public readonly int Row;
        public readonly int Column;
        private bool isSunken;
    }
}
