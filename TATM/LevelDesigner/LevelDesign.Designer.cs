namespace LevelDesign
{
    partial class LevelDesign
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GameBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Minotaur = new System.Windows.Forms.Button();
            this.btn_Theseus = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_TileBlank = new System.Windows.Forms.Button();
            this.btn_TileLeft = new System.Windows.Forms.Button();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_TileUp = new System.Windows.Forms.Button();
            this.btn_TileLeftUp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleName = "Theseus and the Minotaur";
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(974, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "Theseus and the Minotaur";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 77);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GameBoard);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Exit);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Minotaur);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Theseus);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Save);
            this.splitContainer1.Panel2.Controls.Add(this.btn_TileBlank);
            this.splitContainer1.Panel2.Controls.Add(this.btn_TileLeft);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Menu);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Load);
            this.splitContainer1.Panel2.Controls.Add(this.btn_TileUp);
            this.splitContainer1.Panel2.Controls.Add(this.btn_TileLeftUp);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(974, 708);
            this.splitContainer1.SplitterDistance = 690;
            this.splitContainer1.TabIndex = 4;
            // 
            // GameBoard
            // 
            this.GameBoard.AutoSize = true;
            this.GameBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GameBoard.ColumnCount = 2;
            this.GameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameBoard.Location = new System.Drawing.Point(18, 52);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.RowCount = 2;
            this.GameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GameBoard.Size = new System.Drawing.Size(0, 0);
            this.GameBoard.TabIndex = 2;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(75, 497);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(139, 37);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "ExitTile";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Minotaur
            // 
            this.btn_Minotaur.Location = new System.Drawing.Point(75, 454);
            this.btn_Minotaur.Name = "btn_Minotaur";
            this.btn_Minotaur.Size = new System.Drawing.Size(139, 37);
            this.btn_Minotaur.TabIndex = 8;
            this.btn_Minotaur.Text = "Minotaur";
            this.btn_Minotaur.UseVisualStyleBackColor = true;
            this.btn_Minotaur.Click += new System.EventHandler(this.btn_Minotaur_Click);
            // 
            // btn_Theseus
            // 
            this.btn_Theseus.Location = new System.Drawing.Point(75, 411);
            this.btn_Theseus.Name = "btn_Theseus";
            this.btn_Theseus.Size = new System.Drawing.Size(139, 37);
            this.btn_Theseus.TabIndex = 7;
            this.btn_Theseus.Text = "Theseus";
            this.btn_Theseus.UseVisualStyleBackColor = true;
            this.btn_Theseus.Click += new System.EventHandler(this.btn_Theseus_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Save.Location = new System.Drawing.Point(75, 101);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(139, 37);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_TileBlank
            // 
            this.btn_TileBlank.Location = new System.Drawing.Point(75, 325);
            this.btn_TileBlank.Name = "btn_TileBlank";
            this.btn_TileBlank.Size = new System.Drawing.Size(139, 37);
            this.btn_TileBlank.TabIndex = 6;
            this.btn_TileBlank.Text = "TileBlank";
            this.btn_TileBlank.UseVisualStyleBackColor = true;
            this.btn_TileBlank.Click += new System.EventHandler(this.btn_Tile3_Click);
            // 
            // btn_TileLeft
            // 
            this.btn_TileLeft.Location = new System.Drawing.Point(75, 239);
            this.btn_TileLeft.Name = "btn_TileLeft";
            this.btn_TileLeft.Size = new System.Drawing.Size(139, 37);
            this.btn_TileLeft.TabIndex = 3;
            this.btn_TileLeft.Text = "TileLeft";
            this.btn_TileLeft.UseVisualStyleBackColor = true;
            this.btn_TileLeft.Click += new System.EventHandler(this.btn_Tile1_Click);
            // 
            // btn_Menu
            // 
            this.btn_Menu.Location = new System.Drawing.Point(75, 15);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(139, 37);
            this.btn_Menu.TabIndex = 2;
            this.btn_Menu.Text = "Menu";
            this.btn_Menu.UseVisualStyleBackColor = true;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(75, 58);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(139, 37);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_TileUp
            // 
            this.btn_TileUp.Location = new System.Drawing.Point(75, 282);
            this.btn_TileUp.Name = "btn_TileUp";
            this.btn_TileUp.Size = new System.Drawing.Size(139, 37);
            this.btn_TileUp.TabIndex = 5;
            this.btn_TileUp.Text = "TileUp";
            this.btn_TileUp.UseVisualStyleBackColor = true;
            this.btn_TileUp.Click += new System.EventHandler(this.btn_Tile2_Click);
            // 
            // btn_TileLeftUp
            // 
            this.btn_TileLeftUp.Location = new System.Drawing.Point(75, 368);
            this.btn_TileLeftUp.Name = "btn_TileLeftUp";
            this.btn_TileLeftUp.Size = new System.Drawing.Size(139, 37);
            this.btn_TileLeftUp.TabIndex = 4;
            this.btn_TileLeftUp.Text = "TileLeftUp";
            this.btn_TileLeftUp.UseVisualStyleBackColor = true;
            this.btn_TileLeftUp.Click += new System.EventHandler(this.btn_Tile4_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.508197F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.49181F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 788);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LevelDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 812);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LevelDesign";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel GameBoard;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_TileBlank;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_TileUp;
        private System.Windows.Forms.Button btn_Menu;
        private System.Windows.Forms.Button btn_TileLeftUp;
        private System.Windows.Forms.Button btn_TileLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Minotaur;
        private System.Windows.Forms.Button btn_Theseus;
    }
}

