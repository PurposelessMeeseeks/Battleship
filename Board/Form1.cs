using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;

namespace Board
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button201_Click(object sender, EventArgs e)
        {
            List<int> shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var shipwright = new Shipwright(10, 10, shipLengths);
            var fleet = shipwright.CreateFleet();

            foreach (Ship s in fleet.Ships)
            {
                foreach (Square sq in s.Squares)
                {
                    var b = GetButton(sq.Column, sq.Row);
                    b.BackColor = Color.Blue;
                }
            }
           
        }

        private Button GetButton(int Column, int Row)
        {
            switch (Row)
            {
                case 0:
                    switch (Column)
                    {
                        case 0:
                            return button1;
                        case 1:
                            return button2;
                        case 2:
                            return button3;
                        case 3:
                            return button4;
                        case 4:
                            return button5;
                        case 5:
                            return button6;
                        case 6:
                            return button7;
                        case 7:
                            return button8;
                        case 8:
                            return button9;
                        case 9:
                            return button10;
                    }
                    break;
                case 1:
                    switch (Column)
                    {
                        case 0:
                            return button11;
                        case 1:
                            return button12;
                        case 2:
                            return button13;
                        case 3:
                            return button14;
                        case 4:
                            return button15;
                        case 5:
                            return button16;
                        case 6:
                            return button17;
                        case 7:
                            return button18;
                        case 8:
                            return button19;
                        case 9:
                            return button20;
                    }
                    break;
                case 2:
                    switch (Column)
                    {
                        case 0:
                            return button21;
                        case 1:
                            return button22;
                        case 2:
                            return button23;
                        case 3:
                            return button24;
                        case 4:
                            return button25;
                        case 5:
                            return button26;
                        case 6:
                            return button27;
                        case 7:
                            return button28;
                        case 8:
                            return button29;
                        case 9:
                            return button30;
                    }
                    break;
                case 3:
                    switch (Column)
                    {
                        case 0:
                            return button31;
                        case 1:
                            return button32;
                        case 2:
                            return button33;
                        case 3:
                            return button34;
                        case 4:
                            return button35;
                        case 5:
                            return button36;
                        case 6:
                            return button37;
                        case 7:
                            return button38;
                        case 8:
                            return button39;
                        case 9:
                            return button40;
                    }
                    break;
                case 4:
                    switch (Column)
                    {
                        case 0:
                            return button50;
                        case 1:
                            return button49;
                        case 2:
                            return button48;
                        case 3:
                            return button47;
                        case 4:
                            return button46;
                        case 5:
                            return button45;
                        case 6:
                            return button44;
                        case 7:
                            return button43;
                        case 8:
                            return button42;
                        case 9:
                            return button41;
                    }
                    break;
                case 5:
                    switch (Column)
                    {
                        case 0:
                            return button60;
                        case 1:
                            return button59;
                        case 2:
                            return button58;
                        case 3:
                            return button57;
                        case 4:
                            return button56;
                        case 5:
                            return button55;
                        case 6:
                            return button54;
                        case 7:
                            return button53;
                        case 8:
                            return button52;
                        case 9:
                            return button51;
                    }
                    break;
                case 6:
                    switch (Column)
                    {
                        case 0:
                            return button70;
                        case 1:
                            return button69;
                        case 2:
                            return button68;
                        case 3:
                            return button67;
                        case 4:
                            return button66;
                        case 5:
                            return button65;
                        case 6:
                            return button64;
                        case 7:
                            return button63;
                        case 8:
                            return button62;
                        case 9:
                            return button61;
                    }
                    break;
                case 7:
                    switch (Column)
                    {
                        case 0:
                            return button80;
                        case 1:
                            return button79;
                        case 2:
                            return button78;
                        case 3:
                            return button77;
                        case 4:
                            return button76;
                        case 5:
                            return button75;
                        case 6:
                            return button74;
                        case 7:
                            return button73;
                        case 8:
                            return button72;
                        case 9:
                            return button71;
                    }
                    break;
                case 8:
                    switch (Column)
                    {
                        case 0:
                            return button90;
                        case 1:
                            return button89;
                        case 2:
                            return button88;
                        case 3:
                            return button87;
                        case 4:
                            return button86;
                        case 5:
                            return button85;
                        case 6:
                            return button84;
                        case 7:
                            return button83;
                        case 8:
                            return button82;
                        case 9:
                            return button81;
                    }
                    break;
                case 9:
                    switch (Column)
                    {
                        case 0:
                            return button100;
                        case 1:
                            return button99;
                        case 2:
                            return button98;
                        case 3:
                            return button97;
                        case 4:
                            return button96;
                        case 5:
                            return button95;
                        case 6:
                            return button94;
                        case 7:
                            return button93;
                        case 8:
                            return button92;
                        case 9:
                            return button91;
                    }
                    break;
            }
            return null;
        }
    }
}
