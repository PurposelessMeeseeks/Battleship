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

namespace GUI
{
    public partial class Igra : Form
    {
        private readonly int Redci;
        private readonly int Stupci;
        private readonly string PostavljanjeFlote;
        private readonly Gunnery gunnery;
        private readonly Fleet mojaFlota;
        private readonly Fleet protivnickaFlota;

        public Igra(int redci, int stupci, string postavljenjeFlote)
        {
            InitializeComponent();
            Redci = redci;
            Stupci = stupci;
            PostavljanjeFlote = postavljenjeFlote;

            Size s = new Size(2 * Stupci * 40 + 100, Redci * 40 + 55);
            this.Size = this.MaximumSize = this.MinimumSize = s;

            int nextGridPositionX = kreirajGumbeZaGridGadjanja(20,10);

            kreirajGumbeZaGridMojihBrodova(nextGridPositionX + 45, 10);

            var listaBrodova = new List<int>()
            {
                5,
                2,
                3
            };
            ISquareEliminate eliminator;
            if (PostavljanjeFlote.Equals("Brodovi se smiju dodirivati"))
                eliminator = new SimpleSquareEliminator();
            else
                eliminator = new SurroundingSquareEliminator(redci,stupci);

            var shipwright = new Shipwright(redci, stupci, listaBrodova, eliminator);
            mojaFlota = shipwright.CreateFleet();
            protivnickaFlota = shipwright.CreateFleet();

            oznaciMojuFlotu();
            oznaciMojuFlotu2();

            gunnery = new Gunnery(redci, stupci, listaBrodova);
        }

        private int kreirajGumbeZaGridGadjanja(int xPoc, int yPoc)
        {
            return kreirajGumbeZaGrid(xPoc, yPoc, true);
        }


        private void kreirajGumbeZaGridMojihBrodova(int xPoc, int yPoc) 
        {
            kreirajGumbeZaGrid(xPoc, yPoc, false);
        }

        private int kreirajGumbeZaGrid(int xPoc, int yPoc, bool protivnickaFlota)
        {
            Point nextButtonPosition = new Point(xPoc, yPoc);
            Button newButton;
            for (int i=0; i<Stupci; i++)
            {
                nextButtonPosition.X = xPoc;
                for (int j=0; j<Redci; j++)
                {
                    newButton = new Button
                    {
                        Location = nextButtonPosition,
                        Text = ((char)(65 + j)).ToString() + (i + 1),
                        Size = new Size(35, 35)
                    };

                    if (protivnickaFlota)
                    {
                        newButton.Click += onClick;
                        newButton.Name = "btnProtivnickaFlota" + j + i;
                    }
                    else
                    {
                        newButton.Name = "btnMojaFlota" + j + i;
                    }
                    
                    this.Controls.Add(newButton);

                    nextButtonPosition.X += 40;
                }
                nextButtonPosition.Y += 40;
            }
            return nextButtonPosition.X;
        }

        private void onClick(object sender, EventArgs e) 
        {
            var button = (Button)sender;
            button.Click -= onClick;

            var position = button.Text;
            int row = position[0] - 65;
            int col = position[1] - 49;

            Square mojaMeta = new Square(row,col);
            HitResult mojRezultat = protivnickaFlota.Hit(mojaMeta);

            obradiGadjanjeLogic("btnProtivnickaFlota", protivnickaFlota, mojaMeta, button, mojRezultat);

            Square sljedecaMeta = gunnery.NextTarget();
            HitResult protivnickiRezultat = mojaFlota.Hit(sljedecaMeta);
            gunnery.ProcessShootingResult(protivnickiRezultat);

            Button btnMojaFlota = nadjiGumbZaPolje("btnMojaFlota", sljedecaMeta.Row, sljedecaMeta.Column);
            obradiGadjanjeLogic("btnMojaFlota", mojaFlota ,sljedecaMeta, btnMojaFlota, protivnickiRezultat);
        }

        private void obradiGadjanjeLogic(string buttonPrefix, Fleet f, Square sq, Button btn, HitResult hit)
        {
            if (hit == HitResult.Sunken)
                obradiPotapanjeGUI(buttonPrefix, f, sq);
            else
                obradiGadjanjeGUI(btn, hit);
        }

        private Button nadjiGumbZaPolje(string buttonPrefix, int redak, int stupac) 
        {
            return (Button)this.Controls.Find(buttonPrefix + redak + stupac, true).First();
        }

        private void obradiPotapanjeGUI(string buttonPrefix, Fleet f, Square sq)
        {
            Ship s = f.shipOnSquare(sq);
            foreach(Square poljeBroda in s.Squares)
            {
                nadjiGumbZaPolje(buttonPrefix, poljeBroda.Row, poljeBroda.Column).BackColor = Color.Red;
            }
        }


        private void obradiGadjanjeGUI(Button btn, HitResult hit)
        {
            //sunken obrađen iznad
            if (hit == HitResult.Hit)
            {
                btn.BackColor = Color.Orange;
            }
            else
            {
                btn.BackColor = Color.White;
            }
        }

        private void oznaciMojuFlotu()
        {
            mojaFlota.Ships.ToList().ForEach(ship =>
            {
                ship.Squares.ToList().ForEach(square =>
                {
                    nadjiGumbZaPolje("btnMojaFlota", square.Row, square.Column).BackColor = Color.Blue;
                });
            });
        }
        private void oznaciMojuFlotu2()
        {
            protivnickaFlota.Ships.ToList().ForEach(ship =>
            {
                ship.Squares.ToList().ForEach(square =>
                {
                    nadjiGumbZaPolje("btnProtivnickaFlota", square.Row, square.Column).BackColor = Color.Blue;
                });
            });
        }
    }
}
