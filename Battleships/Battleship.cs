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
using System.Threading;

namespace Battleships
{
    enum Turn
    {
        Human,
        PC
    }

    public partial class Battleship : Form
    {
        public Battleship()
        {
            InitializeComponent();

            PCFleetControl.ButtonClick += on_click;

            Shipwright shipwright = new Shipwright(10, 10, new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            Gunnery = new Gunnery(10, 10, new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            PCFleet = shipwright.CreateFleet();
            PlayerFleet = shipwright.CreateFleet();
            PCPlayerThread = new Thread(PCTurn);
            PCPlayerThread.Start();
            IsGameOver = false;
            PlayerFleetControl.PlaceShips(PlayerFleet);
            PCFleetControl.PlaceShips(PCFleet);
            WhoIsNext = Turn.Human;
        }
        
        private void on_click(object sender, EventArgs e)
        {
            var button = (ShipButton)sender;
            if (button == null)
            {
                return;
            }

            if (button.IsSunken == true)
            {
                return;
            }

            if (WhoIsNext == Turn.PC)
            {
                return;
            }

            var row = button.Row;
            var col = button.Column;

            bool isHitted = false;
            foreach (var ships in PCFleet.Ships)
            {
                var hitResult = ships.Hit(new Square(row, col));
                if (hitResult == HitResult.Hit)
                {
                    PCFleetControl.Hit(new Square(row, col));
                    isHitted = true;
                    break;
                }

                if (hitResult == HitResult.Sunken)
                {
                    PCFleetControl.Hit(new Square(row, col));
                    PCFleetControl.SunkShip(ships.Squares);
                    isHitted = true;
                }

            }
            if (!isHitted)
            {
                lock (this)
                {
                    WhoIsNext = Turn.PC;
                }
            }
        }

        void PCTurn()
        {
            while(!IsGameOver)
            {
                if (WhoIsNext == Turn.PC)
                {
                    while (true)
                    {
                        var target = Gunnery.NextTarget();
                        var hitResult = PlayerFleet.Hit(target);
                        Gunnery.RecordShootingResult(hitResult);

                        if (hitResult == HitResult.Missed)
                        {
                            lock (this)
                            {
                                WhoIsNext = Turn.Human;
                            }
                            break;
                        }

                        if (hitResult == HitResult.Hit)
                        {
                            PlayerFleetControl.Hit(target);
                        }

                        if (hitResult == HitResult.Sunken)
                        {
                            foreach (var ships in PlayerFleet.Ships)
                            {
                                int index = Array.FindIndex(ships.Squares.ToArray(), item => item.Equals(target));
                                if (index != -1)
                                {
                                    PlayerFleetControl.Hit(target);
                                    PlayerFleetControl.SunkShip(ships.Squares);
                                    break;
                                }
                            }
                        }      
                        
                        if (PlayerFleet.AreAllSunken() == true)
                        {
                            // END GAME
                        }
                    }
                }
            }
        }

        Fleet PCFleet;
        Fleet PlayerFleet;

        Thread PCPlayerThread;
        Thread PlayerThread;
        Gunnery Gunnery;
        bool IsGameOver;
        Turn WhoIsNext;
    }
}
