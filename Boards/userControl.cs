using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    public partial class userControl : UserControl
    {
        public userControl()
        {
            InitializeComponent();
        }

        private void userControl_Load(object sender, EventArgs e)
        {
            addButton();

        }

        private void addButton()
        {
            int height = this.Size.Height;
            int width = this.Size.Width;

            int widthOffset = 10;
            int heightOffset = 10;

            int btnWidth = 100;  // Button Widht
            int btnHeight = 40;  // Button Height

            for (int i = 0; i < 1; ++i)
            {
                if ((widthOffset + btnWidth) >= width)
                {
                    widthOffset = 10;
                    heightOffset = heightOffset + btnHeight;

                    var button = new Button();
                    button.Size = new Size(btnWidth, btnHeight);
                    button.Name = "" + i + "";
                    button.Text = "" + i + "";
                    //button.Click += button_Click; // Button Click Event
                    button.Location = new Point(widthOffset, heightOffset);

                    Controls.Add(button);

                    widthOffset = widthOffset + (btnWidth);
                }

                else
                {
                    var button = new Button();
                    button.Size = new Size(btnWidth, btnHeight);
                    button.Name = "wooho" + i + "";
                    button.Text = "" + i + "";
                    //button.Click += button_Click; // Button Click Event
                    button.Location = new Point(widthOffset, heightOffset);

                }



            }
        }
    }
}
