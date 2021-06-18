using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;

namespace BattleshipGUI
{
    public partial class MainForm : Form
    {
        private const int nRows = 10;
        private const int nColumns = 10;
        private static int enemyShipsAlive = 10;

        //private static int myShipsAlive = 10;
        //private static int mySquaresAlive = 30;
        private static int enemySquaresAlive = 30;

        public List<int> shipLengths;
        public Fleet myFleet, enemyFleet;
        private readonly Gunnery gunner = new Gunnery(nRows, nColumns, new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
        private readonly GridButton[,] myGridDraw = new GridButton[nRows, nColumns];
        private readonly GridButton[,] enemyGridDraw = new GridButton[nRows, nColumns];

        public MainForm()
        {
            DrawPanel(myGridDraw, 50);
            DrawPanel(enemyGridDraw, 700);
            InitializeComponent();
        }

        // PLACE FLEET BUTTON
        private void PlaceFleetButton_Click(object sender, EventArgs e)
        {
            PlaceMyFleet();
            PlaceEnemyFleet();
            MessageBox.Show("You can start. Good Luck!", "Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PlaceFleetButton.Enabled = false;
        }

        // GRID DRAW
        private void DrawPanel(GridButton[,] gridDraw, int startLeft)
        {
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    gridDraw[i, j] = new GridButton(i, j)
                    {
                        Row = i,
                        Column = j,
                        BackColor = Color.GhostWhite,
                        Location = new Point(startLeft + i * 40, 60 + j * 40),
                        Size = new Size(40, 40),
                        TabStop = false,
                        FlatStyle = FlatStyle.Flat
                    };
                    gridDraw[i, j].FlatAppearance.BorderSize = 1;
                    gridDraw[i, j].FlatAppearance.BorderColor = Color.Black;
                    gridDraw[i, j].Click += ButtonClick;
                    Controls.Add(gridDraw[i, j]);
                }
            }
        }

        // PAINTING SHIP SQUARE FOR MY FLEET
        private void FleetButtonFillColorForMyFleet(int nRows, int nColumn, Color c)
        {
            myGridDraw[nRows, nColumn].BackColor = c;
        }

        // PAINTING SHIP SQUARE FOR ENEMY FLEET
        private void FleetButtonFillColorForEnemyFleet(int nRows, int nColumn, Color c)
        {
            enemyGridDraw[nRows, nColumn].BackColor = c;
        }

        // ANIMATION FOR SINKEN SHIP (MY FLEET)
        private void AnimateColorForMyFleet(int nRows, int nColumn)
        {
            myGridDraw[nRows, nColumn].AnimateButtonColor(Color.DarkRed);
        }

        // ANIMATION FOR SINKEN SHIP (ENEMY FLEET)
        private void AnimateColorForEnemyFleet(int nRows, int nColumn)
        {
            enemyGridDraw[nRows, nColumn].AnimateButtonColor(Color.DarkRed);
        }

        // PLACE MY FLEET
        private void PlaceMyFleet()
        {
            Color myFleetColor = Color.GhostWhite;
            shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Shipwright sw = new Shipwright(10, 10, shipLengths);
            myFleet = sw.CreateFleet(new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });

            try
            {
                if (myFleetColorDialog.ShowDialog() == DialogResult.OK)
                {
                    myFleetColor = myFleetColorDialog.Color;
                    enemyShipsAliveLabel.Text = enemyShipsAlive.ToString();
                    enemySquaresAliveLabel.Text = enemySquaresAlive.ToString();
                }
                else
                {
                    MessageBox.Show("You have to choose color for your fleet!", "Choose color", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (myFleetColorDialog.ShowDialog() == DialogResult.OK)
                    {
                        myFleetColor = myFleetColorDialog.Color;
                        enemyShipsAliveLabel.Text = enemyShipsAlive.ToString();
                        enemySquaresAliveLabel.Text = enemySquaresAlive.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You didn't choose the color, if you want to play start the appliacation again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            foreach (Ship ship in myFleet.Ships)
            {
                foreach (Square sq in ship.Squares)
                {
                    FleetButtonFillColorForMyFleet(sq.row, sq.column, myFleetColor);
                }
            }
        }

        // PLACE ENEMY FLEET
        private void PlaceEnemyFleet()
        {
            Color enemyFleetColor = Color.GhostWhite;
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

        // GAME LOGIC (MY TURN)
        private void ButtonClick(object sender, EventArgs e)
        {
            GridButton btn = sender as GridButton;

            Square sqClicked = new Square(btn.Row, btn.Column);
            HitResult result = enemyFleet.Hit(sqClicked);

            switch (result)
            {
                case HitResult.Missed:
                    btn.BackColor = Color.DarkGray;
                    btn.Enabled = false;
                    EnemyTurn();
                    break;

                case HitResult.Hit:
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                    enemySquaresAlive--;
                    enemySquaresAliveLabel.Text = enemySquaresAlive.ToString();
                    EnemyTurn();
                    break;

                case HitResult.Sunken:
                    foreach (var sunkenSquare in enemyFleet.Ships.Where(s => s.Squares.Contains(sqClicked)).SelectMany(s => s.Squares))
                    {
                        AnimateColorForEnemyFleet(sunkenSquare.row, sunkenSquare.column);
                        btn.Enabled = false;
                    }

                    enemyShipsAlive--;
                    enemySquaresAlive--;
                    enemyShipsAliveLabel.Text = enemyShipsAlive.ToString();
                    enemySquaresAliveLabel.Text = enemySquaresAlive.ToString();

                    if (enemyShipsAlive == 0)
                    {
                        DialogResult msgBoxResult = MessageBox.Show("YOU WON!" + Environment.NewLine + Environment.NewLine +
                            "Press 'OK' if you want to play again or 'Cancel' to exit",
                            "Winner!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (msgBoxResult == DialogResult.OK)
                        {
                            Application.Restart();
                        }
                        else if (msgBoxResult == DialogResult.Cancel)
                        {
                            Application.Exit();
                        }
                    }
                    EnemyTurn();
                    break;

                default:
                    break;
            }
        }

        // GAME LOGIC (ENEMY TURN)
        private void EnemyTurn()
        {
            Square field = gunner.NextTarget();
            HitResult result = myFleet.Hit(field);

            switch (result)
            {
                case HitResult.Missed:
                    myGridDraw[field.row, field.column].BackColor = Color.DarkGray;
                    break;

                case HitResult.Hit:
                    myGridDraw[field.row, field.column].BackColor = Color.Red;
                    break;

                case HitResult.Sunken:
                    foreach (var sunkenSquare in myFleet.Ships.Where(s => s.Squares.Contains(field)).SelectMany(s => s.Squares))
                    {
                        AnimateColorForMyFleet(sunkenSquare.row, sunkenSquare.column);
                    }
                    break;

                default:
                    break;
            }
            gunner.RecordShootingResult(result);
        }
    }
}