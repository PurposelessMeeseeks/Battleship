using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;

namespace Test123
{
    public partial class MainForm : Form
    {
        private const int nRows = 10;
        private const int nColumns = 10;   
        public List<int> shipLengths;
        private Gunnery gunner;
        public Fleet myFleet, enemyFleet;
        private readonly GridButton[,] myGridDraw = new GridButton[nRows, nColumns];
        private readonly GridButton[,] enemyGridDraw = new GridButton[nRows, nColumns];

        public MainForm()
        {
            EmptyGridForMyFleet();
            EmptyStartGridFoEnemyFleet();
            InitializeComponent();            
        }

        private void PlaceFleetButton_Click(object sender, EventArgs e)
        {
            PlaceMyFleet();
            PlaceEnemyFleet();
            MessageBox.Show("You can start. Good Luck!", "Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PlaceFleetButton.Enabled = false;
        }

        private void EmptyGridForMyFleet()
        {
            int buttonWidth = 40;
            int buttonHeight = 40;
            int startX = 40;
            int startY = 90;            

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    myGridDraw[i, j] = new GridButton(i, j)
                    {
                        Location = new Point(startX + (j * buttonHeight), startY + (i * buttonWidth)),
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = Color.GhostWhite,
                        Enabled = false,
                        FlatStyle = FlatStyle.Flat,
                    };
                    myGridDraw[i, j].FlatAppearance.BorderSize = 1;
                    myGridDraw[i, j].FlatAppearance.BorderColor = Color.Black;
                    myGridDraw[i, j].TabStop = false;                    
                    Controls.Add(myGridDraw[i, j]);
                }
            }           
        }

        private void EmptyStartGridFoEnemyFleet()
        {
            int buttonWidth = 40;
            int buttonHeight = 40;
            int startX = 720;
            int startY = 90;

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    enemyGridDraw[i, j] = new GridButton(i, j)
                    {
                        Location = new Point(startX + (j * buttonHeight), startY + (i * buttonWidth)),
                        Size = new Size(40, 40),
                        BackColor = Color.GhostWhite,
                        FlatStyle = FlatStyle.Flat
                    };
                    enemyGridDraw[i, j].FlatAppearance.BorderSize = 1;
                    enemyGridDraw[i, j].FlatAppearance.BorderColor = Color.Black;
                    enemyGridDraw[i, j].Click += MyTurnButtonClick;
                    Controls.Add(enemyGridDraw[i, j]);
                }
            }
        }

        private void PlaceMyFleet()
        {
            Color myFleetColor = Color.DarkSlateGray;
            shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Shipwright sw = new Shipwright(10, 10, shipLengths);
            myFleet = sw.CreateFleet(new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });            

            foreach (Ship ship in myFleet.Ships)
            {
                foreach (Square sq in ship.Squares)
                {
                    FleetButtonFillColorForMyFleet(sq.row, sq.column, myFleetColor);
                }
            }
        }

        private void PlaceEnemyFleet()
        {
            Color enemyFleetColor = Color.Pink;
            shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Shipwright sw = new Shipwright(10, 10, shipLengths);
            enemyFleet = sw.CreateFleet(new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });            

            foreach (Ship ship in enemyFleet.Ships)
            {
                foreach (Square sq in ship.Squares)
                {
                    FleetButtonFillColorForEnemyFleet(sq.row, sq.column, enemyFleetColor);
                }
            }
        }

        // PAINTING SHIP SQUARES FOR MY FLEET
        private void FleetButtonFillColorForMyFleet(int nRows, int nColumn, Color c)
        {
            myGridDraw[nRows, nColumn].BackColor = c;
        }

        // PAINTING SHIP SQUARES FOR ENEMY FLEET
        private void FleetButtonFillColorForEnemyFleet(int nRows, int nColumn, Color c)
        {
            enemyGridDraw[nRows, nColumn].BackColor = c;
        }

        //private void AnimateColorForMyFleet(int nRows, int nColumn)
        //{
        //    myGridDraw[nRows, nColumn].AnimateButtonColor(Color.DarkRed);
        //}

        private void AnimateColorForEnemyFleet(int nRows, int nColumn)
        {
            enemyGridDraw[nRows, nColumn].AnimateButtonColor(Color.DarkRed);
        }

        // GAME LOGIC
        private void MyTurnButtonClick(object sender, EventArgs e)
        {
            GridButton btn = sender as GridButton;
            Square sqClicked = new Square(btn.Row, btn.Column);

            HitResult result = enemyFleet.Hit(sqClicked);
            switch (result)
            {
                case HitResult.Missed:
                    btn.BackColor = Color.DarkGray;
                    btn.Enabled = false;
                    //EnemyPlay();
                    break;
                case HitResult.Hit:
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                    //EnemyPlay();
                    break;
                case HitResult.Sunken:
                    foreach (var sunkenSquare in enemyFleet.Ships.Where(s => s.Squares.Contains(sqClicked)).SelectMany(s => s.Squares))
                    {
                        AnimateColorForEnemyFleet(sunkenSquare.row, sunkenSquare.column);
                        btn.Enabled = false;
                        //EnemyPlay();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
