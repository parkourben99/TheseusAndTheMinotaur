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
        // setting newGame as a var
        NewGame newGame;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            // create the a new instance of NewGame form and show
            newGame = new NewGame();
            newGame.ShowDialog();

            //minamise main form
            //this.WindowState = FormWindowState.Minimized;

            //what the screw do we do? 
            

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            login frmLogin;

            frmLogin = new login();
            frmLogin.ShowDialog();
        }
    }
}
