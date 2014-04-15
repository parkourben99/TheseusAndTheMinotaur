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
    public partial class frmMain : Form
    {
        // from2 as a var
        Form2 newGame;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            // create the new form and show
            newGame = new Form2();
            newGame.ShowDialog();

            //minamise main form
            //this.WindowState = FormWindowState.Minimized;
            

        }
    }
}
