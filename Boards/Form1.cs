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

namespace Boards
{
    public partial class Form1 : Form
    {

        List<Button> buttons = new List<Button>();



        List<int> X = new List<int>();
        List<int> Y = new List<int>();

        enum CurrentPlayer
        {
            Computer,
            Player
        }

        const int rows = 10;
        const int columns = 10;
        readonly IEnumerable<int> shipLengths = new List<int>() {
            5,4,4,3,3,3,2,2,2,2
        };
        


        Fleet fleet;

        Grid recordGrid = new Grid(rows, columns);
        CurrentPlayer currentPlayer;
        Gunnery gunnery;
        private int shipnumber=10;


        private bool Playerturn;
        int colornr = 0;

        private void firstTurn()
        {


            Random rnd = new Random();
            int whoStarts = rnd.Next(0, 2);
            if (whoStarts == 0)
            {
                //PC starts
                Playerturn = false;

                turnLabel.Text = "Oponent's turn";
            }
            else
            {
                // Player starts
                Playerturn = true;

                turnLabel.Text = "Your Turn";
            }
        }

     


        public Form1()
        {
            InitializeComponent();

            firstTurn();

            addButton(0, 0, false); //My Grid
            addButton(600, 0, true); // Enenmy Grid


            gunnery = new Gunnery(rows, columns, shipLengths);
            


        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton(int widthOffset, int heightOffset, bool isEnemyGrid)
        {



            int btnWidth = 40;  // Button Widht
            int btnHeight = 40;



            List<Label> labels = new List<Label>();


            for (int j = 0; j < 10; j++)
            {
                heightOffset += 40;
                widthOffset += 40;
                char n = 'A';



                for (int i = 0; i < 10; i++)
                {

                    int labelwidh = widthOffset + 20;




                    if (j == 0)
                    {

                        Label label = new Label();
                        labels.Add(label);
                        label.Location = new Point(widthOffset, heightOffset + 50);
                        label.Width = 10;
                        label.Height = 40;
                        while (n <= 'J')
                        {
                            label.Text = n.ToString();
                            break;
                        }
                        n++;


                        this.Controls.Add(label);

                    }


                    if (i == 0)
                    {
                        labelwidh += 20;

                        Label label1 = new Label();
                        labels.Add(label1);
                        label1.Location = new Point(labelwidh, heightOffset);
                        label1.Width = btnWidth;
                        label1.Height = btnHeight;
                        label1.Text = (j + 1).ToString();


                        this.Controls.Add(label1);


                    }


                    heightOffset = heightOffset + btnHeight;



                    Button newButton = new Button();
                    buttons.Add(newButton);
                    newButton.Name = i.ToString();
                    newButton.Location = new Point(widthOffset + 20, heightOffset);
                    newButton.Width = btnWidth;
                    newButton.Height = btnHeight;
                    if (isEnemyGrid)
                    {
                        newButton.Name = "enemy" + i.ToString() + j.ToString();
                    }
                    else
                    {
                        newButton.Name = "player" + i.ToString() + j.ToString();
                    }
                    newButton.Click += new EventHandler(newButton_Click);


                    this.Controls.Add(newButton);

                }
                heightOffset = 0;
            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {




            Button buttonClicked = sender as Button;

            string position = buttonClicked.Name;

            MessageBox.Show(buttonClicked.Name);


            if (Playerturn == true)
            {
                turnLabel.Text = "Oponent's Turn";



                for (int i = 0; i <= 9; i++)
                {
                    string enemyname;
                    string playername;
                    for (int j = 0; j <= 9; j++)
                    {
                        playername = "player" + i.ToString() + j.ToString();
                        Button found2 = buttons.FirstOrDefault(b => b.Name == playername);
                        found2.Enabled = true;
                        if(found2.Enabled == false)
                        {
                            found2.Enabled = true;
                        }

                        enemyname = "enemy" + i.ToString() + j.ToString();
                        Button found1 = buttons.FirstOrDefault(b => b.Name == enemyname);
                        found1.Enabled = false;

                      
                    }
                }
                Playerturn = false;


            }
            else if (Playerturn == false)
            {
                turnLabel.Text = "Your Turn";
                
                for (int i = 0; i <= 9; i++)
                {
                    string enemyname;
                    string playername;
                    for (int j = 0; j <= 9; j++)
                    {
                        enemyname = "enemy" + i.ToString() + j.ToString();
                        Button find = buttons.FirstOrDefault(b => b.Name == enemyname);
                        if (find.Enabled == false) { 
                        find.Enabled = true;
                        }


                        playername = "player" + i.ToString() + j.ToString();
                        Button find2 = buttons.FirstOrDefault(b => b.Name == playername);
                        find2.Enabled = false;
                    }
                }
                Playerturn = true;


            }










            string name = position;
            char[] pos = name.ToCharArray();
            int row;
            int column;
            if (pos[0] == 'e')
            {

                column = Int32.Parse(pos[5].ToString());
                row = Int32.Parse(pos[6].ToString());


            }
            else
            {
                column = Int32.Parse(pos[6].ToString());
                row = Int32.Parse(pos[7].ToString());
            }



            var hitResult = fleet.Hit(new Square(row, column));

            Button found = buttons.FirstOrDefault(b => b.Name == name);
            if (found.BackColor == Color.Black)
            {
                found.BackColor = Color.Red;
            }
            else if(found.BackColor == Color.Red)
            {
                found.Enabled = false;
            }
            else
            {
                found.BackColor = Color.White;
            }    
        }





        private Color GetHitColor(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    return Color.Red;
                case HitResult.Sunken:
                    return Color.Black;
                case HitResult.Missed:
                    return Color.White;
            }
            return DefaultBackColor;
        }




        private void resetbtn_Click(object sender, EventArgs e)
        {

            foreach (Button button in buttons)
            {
                button.BackColor = DefaultBackColor;
            }
            Shipwright shipwright = new Shipwright(rows, columns, shipLengths, new SurroundingSquareEliminator(rows, columns));
            fleet = shipwright.CreateFleet();
            
            Grid grid = new Grid(rows, columns);

           





            foreach (Ship ship in fleet.Ships)
            {



                foreach (Square square in ship.Squares)
                {
                    int row = square.Row;
                    int column = square.Column;

                    string name = "player" + row.ToString() + column.ToString();
                    Button found = buttons.FirstOrDefault(b => b.Name == name);

                    found.BackColor = Color.Black;




                   



                }

                foreach (Square square in ship.Squares)
                {
                    int row = square.Row;
                    int column = square.Column;



                    string name = "enemy" + row.ToString() + column.ToString();
                    Button found = buttons.FirstOrDefault(b => b.Name == name);

                    found.BackColor = Color.Black;
                }
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
