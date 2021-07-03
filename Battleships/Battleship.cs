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
    public partial class Battleship : Form
    {
        public  Battleship()
        {
            InitializeComponent();

            PCFleetControl.ButtonClick += on_click;

            manager = new PlayerManager(PCFleetControl, PlayerFleetControl);
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

            manager.EnqueuePlayerNotification(button);
        }

        PlayerManager manager;
    }
}
