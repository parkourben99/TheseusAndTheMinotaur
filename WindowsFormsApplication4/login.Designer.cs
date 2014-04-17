namespace WindowsFormsApplication4
{
    partial class login
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblLinkRegister = new System.Windows.Forms.LinkLabel();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.lblLinkForgoten = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(186, 149);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(21, 48);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Username";
            // 
            // lblLinkRegister
            // 
            this.lblLinkRegister.AutoSize = true;
            this.lblLinkRegister.Location = new System.Drawing.Point(21, 137);
            this.lblLinkRegister.Name = "lblLinkRegister";
            this.lblLinkRegister.Size = new System.Drawing.Size(46, 13);
            this.lblLinkRegister.TabIndex = 2;
            this.lblLinkRegister.TabStop = true;
            this.lblLinkRegister.Text = "Register";
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Location = new System.Drawing.Point(21, 87);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(53, 13);
            this.lblPassWord.TabIndex = 3;
            this.lblPassWord.Text = "Password";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(96, 149);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(82, 48);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(100, 20);
            this.txbUserName.TabIndex = 5;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(82, 87);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.PasswordChar = '*';
            this.txbPassWord.Size = new System.Drawing.Size(100, 20);
            this.txbPassWord.TabIndex = 6;
            // 
            // lblLinkForgoten
            // 
            this.lblLinkForgoten.AutoSize = true;
            this.lblLinkForgoten.Location = new System.Drawing.Point(21, 115);
            this.lblLinkForgoten.Name = "lblLinkForgoten";
            this.lblLinkForgoten.Size = new System.Drawing.Size(98, 13);
            this.lblLinkForgoten.TabIndex = 7;
            this.lblLinkForgoten.TabStop = true;
            this.lblLinkForgoten.Text = "Forgoten Password";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 24);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Theseus and the Minotaur";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 184);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLinkForgoten);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.lblLinkRegister);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.LinkLabel lblLinkRegister;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.LinkLabel lblLinkForgoten;
        private System.Windows.Forms.Label lblTitle;
    }
}