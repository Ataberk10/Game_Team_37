namespace GameVsComputer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtStartNumber;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.ComboBox cmbStartPlayer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnMult2;
        private System.Windows.Forms.Button btnMult3;
        private System.Windows.Forms.Button btnMult4;
        private System.Windows.Forms.Label lblCurrentNumber;
        private System.Windows.Forms.Label lblScores;

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
            this.txtStartNumber = new System.Windows.Forms.TextBox();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.cmbStartPlayer = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnMult2 = new System.Windows.Forms.Button();
            this.btnMult3 = new System.Windows.Forms.Button();
            this.btnMult4 = new System.Windows.Forms.Button();
            this.lblCurrentNumber = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStartNumber
            // 
            this.txtStartNumber.Location = new System.Drawing.Point(20, 20);
            this.txtStartNumber.Name = "txtStartNumber";
            this.txtStartNumber.Size = new System.Drawing.Size(100, 22);
            this.txtStartNumber.TabIndex = 0;
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.Location = new System.Drawing.Point(140, 20);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(121, 24);
            this.cmbAlgorithm.TabIndex = 1;
            // 
            // cmbStartPlayer
            // 
            this.cmbStartPlayer.Location = new System.Drawing.Point(280, 20);
            this.cmbStartPlayer.Name = "cmbStartPlayer";
            this.cmbStartPlayer.Size = new System.Drawing.Size(121, 24);
            this.cmbStartPlayer.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(420, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Game";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnMult2
            // 
            this.btnMult2.Location = new System.Drawing.Point(20, 60);
            this.btnMult2.Name = "btnMult2";
            this.btnMult2.Size = new System.Drawing.Size(75, 30);
            this.btnMult2.TabIndex = 4;
            this.btnMult2.Text = "x2";
            this.btnMult2.Click += new System.EventHandler(this.btnMult2_Click);
            // 
            // btnMult3
            // 
            this.btnMult3.Location = new System.Drawing.Point(110, 60);
            this.btnMult3.Name = "btnMult3";
            this.btnMult3.Size = new System.Drawing.Size(75, 30);
            this.btnMult3.TabIndex = 5;
            this.btnMult3.Text = "x3";
            this.btnMult3.Click += new System.EventHandler(this.btnMult3_Click);
            // 
            // btnMult4
            // 
            this.btnMult4.Location = new System.Drawing.Point(200, 60);
            this.btnMult4.Name = "btnMult4";
            this.btnMult4.Size = new System.Drawing.Size(75, 30);
            this.btnMult4.TabIndex = 6;
            this.btnMult4.Text = "x4";
            this.btnMult4.Click += new System.EventHandler(this.btnMult4_Click);
            // 
            // lblCurrentNumber
            // 
            this.lblCurrentNumber.Location = new System.Drawing.Point(20, 110);
            this.lblCurrentNumber.Name = "lblCurrentNumber";
            this.lblCurrentNumber.Size = new System.Drawing.Size(300, 20);
            this.lblCurrentNumber.TabIndex = 7;
            this.lblCurrentNumber.Text = "Current Number: -";
            // 
            // lblScores
            // 
            this.lblScores.Location = new System.Drawing.Point(20, 140);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(400, 20);
            this.lblScores.TabIndex = 8;
            this.lblScores.Text = "Scores: -";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(197, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ataberk AKCIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartNumber);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.cmbStartPlayer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnMult2);
            this.Controls.Add(this.btnMult3);
            this.Controls.Add(this.btnMult4);
            this.Controls.Add(this.lblCurrentNumber);
            this.Controls.Add(this.lblScores);
            this.Name = "Form1";
            this.Text = "Game_Team_37 - AI Game - Minimax vs Alpha-Beta ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

