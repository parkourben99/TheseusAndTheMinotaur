namespace LevelDesign
{
    partial class LevelSave
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.txtPubName = new System.Windows.Forms.TextBox();
            this.lblPubName = new System.Windows.Forms.Label();
            this.lblLevelName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLevelName
            // 
            this.txtLevelName.Location = new System.Drawing.Point(300, 35);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(220, 20);
            this.txtLevelName.TabIndex = 0;
            // 
            // txtPubName
            // 
            this.txtPubName.Location = new System.Drawing.Point(300, 118);
            this.txtPubName.Name = "txtPubName";
            this.txtPubName.Size = new System.Drawing.Size(220, 20);
            this.txtPubName.TabIndex = 1;
            // 
            // lblPubName
            // 
            this.lblPubName.AutoSize = true;
            this.lblPubName.Location = new System.Drawing.Point(200, 121);
            this.lblPubName.Name = "lblPubName";
            this.lblPubName.Size = new System.Drawing.Size(53, 13);
            this.lblPubName.TabIndex = 2;
            this.lblPubName.Text = "Publisher:";
            // 
            // lblLevelName
            // 
            this.lblLevelName.AutoSize = true;
            this.lblLevelName.Location = new System.Drawing.Point(200, 38);
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.Size = new System.Drawing.Size(67, 13);
            this.lblLevelName.TabIndex = 3;
            this.lblLevelName.Text = "Level Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 71);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(179, 71);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LevelSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 174);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLevelName);
            this.Controls.Add(this.lblPubName);
            this.Controls.Add(this.txtPubName);
            this.Controls.Add(this.txtLevelName);
            this.Name = "LevelSave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.TextBox txtPubName;
        private System.Windows.Forms.Label lblPubName;
        private System.Windows.Forms.Label lblLevelName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
