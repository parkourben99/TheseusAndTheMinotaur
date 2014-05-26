using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamePlayer.game;
namespace GamePlayer
{
    public partial class MainForm : Form
    {
        // setting newGame as a var
        public MainForm()
        {
            InitializeComponent();
            StorageManagement.StorageManagement.initLevels();
        }
        //new game button
        private void button1_Click(object sender, EventArgs e)
        {

            

            // create the a new instance of gameplayer form and show
            using (GameController.CurrentGame = new GamePlayerForm() )
            {
                GameController.CurrentGame.ShowDialog();
                while (GameController.CurrentGame.getPanel().Focused)
                {
                    //while the game is focused update the game player
                    GameController.CurrentGame.updatePlayer();
                }
            }

            //minamise main form
            //this.WindowState = FormWindowState.Minimized;

            //what the screw do we do? 
            
            //THIS IS RIDICULE

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                 login frmLogin;

                frmLogin = new login();
                frmLogin.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLevelDesign_Click(object sender, EventArgs e)
        {
            var levelDesigner = new LevelDesign.LevelDesign();
            levelDesigner.ShowDialog();
        }
    }
}
