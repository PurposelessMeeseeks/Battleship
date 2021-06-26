
namespace GUI
{
    partial class Meni
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(307, 85);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "POKRENI IGRU";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 104);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(307, 85);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "POSTAVKE";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(307, 85);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "IZLAZ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Meni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 353);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStart);
            this.MaximumSize = new System.Drawing.Size(350, 400);
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "Meni";
            this.Text = "Main menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;
    }
}

