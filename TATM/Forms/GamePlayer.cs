using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StorageManagement;
using GamePlayer.game;
using System.Timers;


namespace GamePlayer
{
    public partial class GamePlayerForm : Form
    {
        GameInstance currentGameInstance;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        Reigndear renderer = new Reigndear();
        public Reigndear Renderer
        {
            get { return renderer; }
            set { renderer = value; }
        }
        public GameInstance CurrentGameInstance
        {
            get { return currentGameInstance; }
            set { currentGameInstance = value; }
        }
       
        public GamePlayerForm()
        {
            InitializeComponent();
        //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGame_KeyDown);
            this.pnlGame.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;         
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            currentGameInstance = new GameInstance();
            renderer.initialiseGraphics(getPanel().CreateGraphics());
            currentGameInstance.newLevel(GameController.loadLevel());
          
        }
       
        private void btnUp_Click(object sender, EventArgs e)
        {
            this.currentGameInstance.moveTheseus("up");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            this.currentGameInstance.moveTheseus("left");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            this.currentGameInstance.moveTheseus("right");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            this.currentGameInstance.moveTheseus("down");
        }

        public enum keys 
        {
            up = 'w', down = 's', left = 'a', right = 'd'
        }

        private void NewGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlGame.Focus();

            switch (e.KeyChar)
            {

                case (char)keys.up:
                    this.currentGameInstance.moveTheseus("up");
                    break;
                case (char)keys.down:
                    this.currentGameInstance.moveTheseus("down");
                    break;
                case (char)keys.left:
                    this.currentGameInstance.moveTheseus("left");
                    break;
                case (char)keys.right:
                    this.currentGameInstance.moveTheseus("right");
                    break;

            }
        }

        private void lblMoves_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
        }

        private void bntMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public System.Windows.Forms.Panel getPanel()
        {
            System.Windows.Forms.Panel panel = pnlGame;
            return panel;
        }

        public void winLose(string state)
        {
            switch (state)
            {
                case "win":
                    MessageBox.Show("You win Congrats!");                   
                    //init collect high scores GameController.sendHighscores(score);
                    break;
                case "lose":
                    MessageBox.Show("You Lose!");
                    
                    break;
            }
        }
        public void updatePlayer()
        {
            while (timer.Enabled) {
            lblScore.Text = currentGameInstance.CurrentScore.ToString();
            lblMoves.Text = currentGameInstance.CurrentMoves.ToString();
            lblTime.Text = timer.ToString();
                }
        }
        
    }
}
