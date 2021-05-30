using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;

namespace Board
{
    public partial class Board : Form
    {
        public Board()
        {
            InitializeComponent();

            enemyButtons = new [,]{

             /* 1.stupac    2.stupac   3.stupac   4.stupac   5.stupac   6.stupac   7.stupac   8.stupac   9.stupac   10.stupac */
                {button200, button199, button198, button197, button196, button195, button194, button193, button192, button191}, // 1. red
                {button190, button189, button188, button187, button186, button185, button184, button183, button182, button181}, // 2. red
                {button180, button179, button178, button177, button176, button175, button174, button173, button172, button171}, // 3. red
                {button170, button169, button168, button167, button166, button165, button164, button163, button162, button161}, // 4. red
                {button160, button159, button158, button157, button156, button155, button154, button153, button152, button151}, // 5. red
                {button150, button149, button148, button147, button146, button145, button144, button143, button142, button141}, // 6. red
                {button140, button139, button138, button137, button136, button135, button134, button133, button132, button131}, // 7. red
                {button130, button129, button128, button127, button126, button125, button124, button123, button122, button121}, // 8. red
                {button120, button119, button118, button117, button116, button115, button114, button113, button112, button111}, // 9. red
                {button110, button109, button108, button107, button106, button105, button104, button103, button102, button101}, // 10. red
            };            
            
            myButtons = new [,]{

             /* 1.stupac    2.stupac   3.stupac   4.stupac   5.stupac   6.stupac   7.stupac   8.stupac   9.stupac   10.stupac */
                {button1, button2, button3, button4, button5, button6, button7, button8, button9, button10}, // 1. red
                {button11, button12, button13, button14, button15, button16, button17, button18, button19, button20}, // 2. red
                {button21, button22, button23, button24, button25, button26, button27, button28, button29, button30}, // 3. red
                {button31, button32, button33, button34, button35, button36, button37, button38, button39, button40}, // 4. red
                {button50, button49, button48, button47, button46, button45, button44, button43, button42, button41}, // 5. red
                {button60, button59, button58, button57, button56, button55, button54, button53, button52, button51}, // 6. red
                {button70, button69, button68, button67, button66, button65, button64, button63, button62, button61}, // 7. red
                {button80, button79, button78, button77, button76, button75, button74, button73, button72, button71}, // 8. red
                {button90, button89, button88, button87, button86, button85, button84, button83, button82, button81}, // 9. red
                {button100, button99, button98, button97, button96, button95, button94, button93, button92, button91}, // 10. red
            };

            shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            shipwright = new Shipwright(10, 10, shipLengths);
            gunnery = new Gunnery(10, 10, shipLengths);

            MyShipsAlive = shipLengths.Count;
            AiShipsAlive = shipLengths.Count;

            labelMyShipsAlive.Text = MyShipsAlive.ToString();
            labelAiShipsAlive.Text = AiShipsAlive.ToString();
        }

        private void PlaceFleetButton_Click(object sender, EventArgs e)
        {
            CreateShips();
            PlaceFleetButton.Enabled = false;
        }

        private void CreateShips()
        {

            myFleet = shipwright.CreateFleet();
            aiFleet = shipwright.CreateFleet();

            foreach (Ship s in myFleet.Ships)
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

        private List<int> shipLengths;
        private Shipwright shipwright;
        private Gunnery gunnery;
        private Fleet myFleet;
        private Fleet aiFleet;
        private HitResult result = HitResult.Missed;

        private Button[,] enemyButtons;
        private Button[,] myButtons;

        private int MyShipsAlive;
        private int AiShipsAlive;

        private void mySemaphore(Square sq, Button button)
        {
            foreach (Ship ship in aiFleet.Ships)
            {
                result = ship.Hit(sq);

                if (result == HitResult.Hit)
                {
                    button.BackColor = Color.Red;
                    break;
                }
                if (result == HitResult.Sunken)
                {
                    foreach (Square square in ship.Squares)
                    {
                        enemyButtons[square.Row, square.Column].BackColor = Color.Black;
                    }
                    AiShipsAlive -= 1;
                    labelAiShipsAlive.Text = AiShipsAlive.ToString();
                    CheckResults();
                    break;
                }
                button.BackColor = Color.Green;
            }
            button.Enabled = false;
            aiSemaphore();
        }

        private void aiSemaphore()
        {
            Square Target = gunnery.NextTarget();
            Button button = GetButton(Target.Column, Target.Row);

            foreach (Ship ship in myFleet.Ships)
            {
                result = ship.Hit(Target);

                if (result == HitResult.Hit)
                {
                    button.BackColor = Color.Red;
                    break;
                }
                if (result == HitResult.Sunken)
                {
                    foreach (Square square in ship.Squares)
                    {
                        myButtons[square.Row, square.Column].BackColor = Color.Black;
                    }
                    MyShipsAlive -= 1;
                    labelMyShipsAlive.Text = MyShipsAlive.ToString();
                    CheckResults();
                    break;
                }
            }
            if (result == HitResult.Missed)
                button.BackColor = Color.Green;
            gunnery.RecordShootingResult(result);
        }

        private void CheckResults()
        {
            if (MyShipsAlive == 0)
                if (MessageBox.Show("Ai Won!", "Looser", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();            
            
            if (AiShipsAlive == 0)
                if (MessageBox.Show("You Won!", "Winner", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();
        }
        private void button200_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 0), button200);
        }

        private void button199_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 1), button199);
        }

        private void button198_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 2), button198);
        }

        private void button197_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 3), button197);
        }

        private void button196_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 4), button196);
        }

        private void button195_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 5), button195);
        }

        private void button194_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 6), button194);
        }

        private void button193_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 7), button193);
        }

        private void button192_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 8), button192);
        }

        private void button191_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(0, 9), button191);
        }

        private void button190_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 0), button190);
        }

        private void button189_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 1), button189);
        }

        private void button188_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 2), button188);
        }

        private void button187_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 3), button187);
        }

        private void button186_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 4), button186);
        }

        private void button185_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 5), button185);
        }

        private void button184_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 6), button184);
        }

        private void button183_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 7), button183);
        }

        private void button182_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 8), button182);
        }

        private void button181_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(1, 9), button181);
        }

        private void button180_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 0), button180);
        }

        private void button179_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 1), button179);
        }

        private void button178_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 2), button178);
        }

        private void button177_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 3), button177);
        }

        private void button176_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 4), button176);
        }

        private void button175_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 5), button175);
        }

        private void button174_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 6), button174);
        }

        private void button173_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 7), button173);
        }

        private void button172_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 8), button172);
        }

        private void button171_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(2, 9), button171);
        }

        private void button170_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 0), button170);
        }

        private void button169_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 1), button169);
        }

        private void button168_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 2), button168);
        }

        private void button167_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 3), button167);
        }

        private void button166_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 4), button166);
        }

        private void button165_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 5), button165);
        }

        private void button164_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 6), button164);
        }

        private void button163_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 7), button163);
        }

        private void button162_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 8), button162);
        }

        private void button161_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(3, 9), button161);
        }

        private void button160_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 0), button160);
        }

        private void button159_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 1), button159);
        }

        private void button158_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 2), button158);
        }

        private void button157_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 3), button157);
        }

        private void button156_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 4), button156);
        }

        private void button155_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 5), button155);
        }

        private void button154_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 6), button154);
        }

        private void button153_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 7), button153);
        }

        private void button152_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 8), button152);
        }

        private void button151_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(4, 9), button151);
        }

        private void button150_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 0), button150);
        }

        private void button149_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 1), button149);
        }

        private void button148_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 2), button148);
        }

        private void button147_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 3), button147);
        }

        private void button146_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 4), button146);
        }

        private void button145_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 5), button145);
        }

        private void button144_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 6), button144);
        }

        private void button143_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 7), button143);
        }

        private void button142_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 8), button142);
        }

        private void button141_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(5, 9), button141);
        }

        private void button140_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 0), button140);
        }

        private void button139_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 1), button139);
        }

        private void button138_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 2), button138);
        }

        private void button137_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 3), button137);
        }

        private void button136_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 4), button136);
        }

        private void button135_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 5), button135);
        }

        private void button134_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 6), button134);

        }

        private void button133_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 7), button133);
        }

        private void button132_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 8), button132);
        }

        private void button131_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(6, 9), button131);
        }

        private void button130_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 0), button130);
        }

        private void button129_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 1), button129);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 2), button128);
        }

        private void button127_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 3), button127);
        }

        private void button126_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 4), button126);
        }

        private void button125_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 5), button125);
        }

        private void button124_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 6), button124);
        }

        private void button123_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 7), button123);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 8), button122);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(7, 9), button121);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 0), button120);
        }

        private void button119_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 1), button119);
        }

        private void button118_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 2), button118);
        }

        private void button117_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 3), button117);
        }

        private void button116_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 4), button116);
        }

        private void button115_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 5), button115);
        }

        private void button114_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 6), button114);
        }

        private void button113_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 7), button113);
        }

        private void button112_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 8), button112);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(8, 9), button111);
        }

        private void button110_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 0), button110);
        }

        private void button109_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 1), button109);
        }

        private void button108_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 2), button108);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 3), button107);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 4), button106);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 5), button105);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 6), button104);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 7), button103);
        }

        private void button102_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 8), button102);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            mySemaphore(new Square(9, 9), button101);
        }
    }
}
