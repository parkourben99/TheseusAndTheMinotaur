using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class NewGame : Form
    {

        public NewGame()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry no help here :( ", "Help");
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

            

            using (Graphics g = pnlGame.CreateGraphics())
            {
                string wallHorizontalImg = @"C:\Users\Benjamin Ayles\Desktop\Project\TheseusAndTheMinotaur\WindowsFormsApplication4\Images\Walls\horizontal.png";
                Image wallHorizontal = Image.FromFile(wallHorizontalImg);
                g.DrawImage(wallHorizontal, new Point(0,0));
            }



        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            string levelTest = "233311244113441144413333";

            buildLevel(levelTest);
        }


        protected void bulidLevel(string levelName)
        {

           //write the method to where to wall is placed

        }
    }
}
