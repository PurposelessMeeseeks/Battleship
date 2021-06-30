
namespace Battleships
{
    partial class Battleship
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerFleetControl = new Battleships.FleetControl();
            this.PCFleetControl = new Battleships.FleetControl();
            this.SuspendLayout();
            // 
            // fleetControl
            // 
            this.PlayerFleetControl.Location = new System.Drawing.Point(12, 12);
            this.PlayerFleetControl.Name = "fleetControl";
            this.PlayerFleetControl.Size = new System.Drawing.Size(397, 407);
            this.PlayerFleetControl.TabIndex = 0;
            // 
            // fleetControl1
            // 
            this.PCFleetControl.Location = new System.Drawing.Point(415, 12);
            this.PCFleetControl.Name = "fleetControl1";
            this.PCFleetControl.Size = new System.Drawing.Size(399, 393);
            this.PCFleetControl.TabIndex = 1;
            // 
            // Battleship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 429);
            this.Controls.Add(this.PCFleetControl);
            this.Controls.Add(this.PlayerFleetControl);
            this.Name = "Battleship";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FleetControl PlayerFleetControl;
        private FleetControl PCFleetControl;
    }
}

