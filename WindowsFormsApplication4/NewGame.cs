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

       // frmMain frmMain4;

        //minamise main form
      //  frmMain.ControlCollectionl
            

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
    }
}
