namespace GamePlayer
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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnLevelDesign = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMain = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(50, 62);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(113, 37);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLevelDesign
            // 
            this.btnLevelDesign.Location = new System.Drawing.Point(50, 105);
            this.btnLevelDesign.Name = "btnLevelDesign";
            this.btnLevelDesign.Size = new System.Drawing.Size(113, 35);
            this.btnLevelDesign.TabIndex = 2;
            this.btnLevelDesign.Text = "Create Level";
            this.btnLevelDesign.UseVisualStyleBackColor = true;
            this.btnLevelDesign.Click += new System.EventHandler(this.btnLevelDesign_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(50, 269);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 35);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Location = new System.Drawing.Point(47, 22);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(131, 13);
            this.lblMain.TabIndex = 4;
            this.lblMain.Text = "Theseus and the Minotaur";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GamePlayer.Properties.Resources.bcy5ABocL;
            this.pictureBox1.Location = new System.Drawing.Point(350, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 449);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(50, 228);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(113, 35);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnHighScores
            // 
            this.btnHighScores.Location = new System.Drawing.Point(50, 187);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(113, 35);
            this.btnHighScores.TabIndex = 7;
            this.btnHighScores.Text = "High Scores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(50, 146);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(113, 35);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLevelDesign);
            this.Controls.Add(this.btnNewGame);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnLevelDesign;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Button btnLogin;
    }
}

