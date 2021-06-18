
namespace BattleshipGUI
{
    partial class MainForm
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
            this.PlaceFleetButton = new System.Windows.Forms.Button();
            this.myFleetColorDialog = new System.Windows.Forms.ColorDialog();
            this.enemyShipsAliveLabel = new System.Windows.Forms.Label();
            this.enemyShipsAliveText = new System.Windows.Forms.Label();
            this.enemySquaresAliveLabel = new System.Windows.Forms.Label();
            this.enemySquaresAliveText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlaceFleetButton
            // 
            this.PlaceFleetButton.Location = new System.Drawing.Point(510, 466);
            this.PlaceFleetButton.Name = "PlaceFleetButton";
            this.PlaceFleetButton.Size = new System.Drawing.Size(75, 23);
            this.PlaceFleetButton.TabIndex = 0;
            this.PlaceFleetButton.Text = "Place Fleet";
            this.PlaceFleetButton.UseVisualStyleBackColor = true;
            this.PlaceFleetButton.Click += new System.EventHandler(this.PlaceFleetButton_Click);
            // 
            // enemyShipsAliveLabel
            // 
            this.enemyShipsAliveLabel.AutoSize = true;
            this.enemyShipsAliveLabel.Location = new System.Drawing.Point(803, 19);
            this.enemyShipsAliveLabel.Name = "enemyShipsAliveLabel";
            this.enemyShipsAliveLabel.Size = new System.Drawing.Size(0, 13);
            this.enemyShipsAliveLabel.TabIndex = 1;
            // 
            // enemyShipsAliveText
            // 
            this.enemyShipsAliveText.AutoSize = true;
            this.enemyShipsAliveText.Location = new System.Drawing.Point(742, 19);
            this.enemyShipsAliveText.Name = "enemyShipsAliveText";
            this.enemyShipsAliveText.Size = new System.Drawing.Size(61, 13);
            this.enemyShipsAliveText.TabIndex = 2;
            this.enemyShipsAliveText.Text = "Ships alive:";
            // 
            // enemySquaresAliveLabel
            // 
            this.enemySquaresAliveLabel.AutoSize = true;
            this.enemySquaresAliveLabel.Location = new System.Drawing.Point(947, 19);
            this.enemySquaresAliveLabel.Name = "enemySquaresAliveLabel";
            this.enemySquaresAliveLabel.Size = new System.Drawing.Size(0, 13);
            this.enemySquaresAliveLabel.TabIndex = 3;
            // 
            // enemySquaresAliveText
            // 
            this.enemySquaresAliveText.AutoSize = true;
            this.enemySquaresAliveText.Location = new System.Drawing.Point(884, 19);
            this.enemySquaresAliveText.Name = "enemySquaresAliveText";
            this.enemySquaresAliveText.Size = new System.Drawing.Size(66, 13);
            this.enemySquaresAliveText.TabIndex = 4;
            this.enemySquaresAliveText.Text = "Squares left:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 513);
            this.Controls.Add(this.enemySquaresAliveText);
            this.Controls.Add(this.enemySquaresAliveLabel);
            this.Controls.Add(this.enemyShipsAliveText);
            this.Controls.Add(this.enemyShipsAliveLabel);
            this.Controls.Add(this.PlaceFleetButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Battleship";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlaceFleetButton;
        private System.Windows.Forms.ColorDialog myFleetColorDialog;
        private System.Windows.Forms.Label enemyShipsAliveLabel;
        private System.Windows.Forms.Label enemyShipsAliveText;
        private System.Windows.Forms.Label enemySquaresAliveLabel;
        private System.Windows.Forms.Label enemySquaresAliveText;
    }
}

