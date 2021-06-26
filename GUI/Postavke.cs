using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Postavke : Form
    {
        private int BrojStupaca;
        private int BrojRedaka;
        private string PostavljanjeFlote;

        public Postavke()
        {
            InitializeComponent();
            cBoxStupac.SelectedValue = Properties.Settings.Default.BrojStupaca;
            cBoxRedak.SelectedValue = Properties.Settings.Default.BrojRedaka;
            cBoxFlota.SelectedValue = Properties.Settings.Default.PostavljanjeFlote;

            int i = cBoxRedak.FindString(Properties.Settings.Default.BrojRedaka.ToString());
            cBoxRedak.SelectedIndex = i;

            i = cBoxStupac.FindString(Properties.Settings.Default.BrojStupaca.ToString());
            cBoxStupac.SelectedIndex = i;

            i = cBoxFlota.FindString(Properties.Settings.Default.PostavljanjeFlote);
            cBoxFlota.SelectedIndex = i;
        }

        private void cBoxRedak_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrojRedaka = Int32.Parse(cBoxRedak.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Želite li spremiti postavke?", "Spremi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                spremi();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.BrojStupaca != BrojStupaca
                || Properties.Settings.Default.BrojRedaka != BrojRedaka
                || Properties.Settings.Default.PostavljanjeFlote != PostavljanjeFlote)
            {
                DialogResult dialogResult = MessageBox.Show("Niste spremili postavke, želite li ih spremiti prije izlaska?", "Spremi", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    spremi();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void spremi()
        {
            Properties.Settings.Default.BrojStupaca = BrojStupaca;
            Properties.Settings.Default.BrojRedaka = BrojRedaka;
            if(PostavljanjeFlote != null)
                Properties.Settings.Default.PostavljanjeFlote = PostavljanjeFlote;

            Properties.Settings.Default.Save();
        }

        private void cBoxStupac_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrojStupaca = Int32.Parse(cBoxStupac.Text);
        }

        private void cBoxFlota_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostavljanjeFlote = cBoxFlota.Text;
        }
    }
}
