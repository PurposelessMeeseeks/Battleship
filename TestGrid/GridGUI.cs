using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;

namespace TestGrid
{
    public partial class GridGUI : Form
    {
        private readonly List<Button> myFleetBattleGround = new List<Button>();
        private readonly List<Button> evidenceBattleGround = new List<Button>();
        private readonly int nRows = 10;
        private readonly int nColumns = 10;
        private Gunnery gunnery;
        private Fleet myFleet;
        private List<int> shipLengths;

        public GridGUI()
        {
            InitializeComponent();
            EmptyStartGridForMyFleet();
            EmptyEvidenceGrid();
        }

        private void EmptyStartGridForMyFleet()
        {
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    int drawIndex = i * 10 + j;
                    Button b = new Button
                    {
                        Location = new System.Drawing.Point(40 + j * 40, 90 + i * 40),
                        Size = new System.Drawing.Size(40, 40),
                        Enabled = false
                    };
                    Controls.Add(b);
                    myFleetBattleGround.Add(b);
                    myFleetBattleGround[drawIndex].FlatStyle = FlatStyle.Flat;
                    myFleetBattleGround[drawIndex].FlatAppearance.BorderSize = 1;
                    myFleetBattleGround[drawIndex].BackColor = Color.WhiteSmoke;
                    myFleetBattleGround[drawIndex].BringToFront();
                }
            }
        }

        private void EmptyEvidenceGrid()
        {
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    int drawIndex = i * 10 + j;
                    Button b = new Button
                    {
                        Location = new System.Drawing.Point(720 + j * 40, 90 + i * 40),
                        Size = new System.Drawing.Size(40, 40),
                        Enabled = false
                    };
                    Controls.Add(b);
                    evidenceBattleGround.Add(b);
                    evidenceBattleGround[drawIndex].FlatStyle = FlatStyle.Flat;
                    evidenceBattleGround[drawIndex].FlatAppearance.BorderSize = 1;
                    evidenceBattleGround[drawIndex].BackColor = Color.WhiteSmoke;
                    evidenceBattleGround[drawIndex].Enabled = true;
                    evidenceBattleGround[drawIndex].BringToFront();
                }
            }
        }

        private void PlaceMyFleet()
        {
            shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Shipwright sw = new Shipwright(10, 10, shipLengths);
            myFleet = sw.CreateFleet(new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            gunnery = new Gunnery(10, 10, shipLengths);

            for (int i = 0; i < nRows; ++i)
            {
                for (int j = 0; j < nColumns; ++j)
                {
                    int drawIndex = i * 10 + j;
                    for (int k = 0; k < myFleet.Ships.Count(); ++k)
                    {
                        if (myFleet.Ships.ElementAt(k).Squares.Contains(new Square(i, j)))
                        {
                            myFleetBattleGround[drawIndex].BackColor = Color.DarkSlateGray;
                            myFleetBattleGround[drawIndex].BringToFront();
                            break;
                        }
                        else
                        {
                            myFleetBattleGround[drawIndex].BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }

        private void PlaceFleet_Click(object sender, EventArgs e)
        {
            PlaceMyFleet();
        }
    }
}