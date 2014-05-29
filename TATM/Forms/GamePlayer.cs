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
        // instance of game used by the form
        GameInstance currentGameInstance;

        // the game renderer
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
        public void sizePanel()
        {
            pnlGame.Width = pnlGame.Height;
        }

        public void setRatio()
        {          
            int ratio = (pnlGame.Height / (currentGameInstance.MyLevel.Height - 1));
            renderer.Ratio = ratio;
        }
        public GamePlayerForm()
        {
            InitializeComponent();
        //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGame_KeyDown);
            this.pnlGame.Focus();
        }
        // on load maximise the game screen
        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;         
        }
        // exit the game player
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // show game help i.e. controls
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry no help here :( ", "Help");
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            
        }
        // loads a new game
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // create a new game instance
            currentGameInstance = new GameInstance();
            // set the panel as graphics location
            renderer.initialiseGraphics(getPanel().CreateGraphics());
            // set game instance level
            currentGameInstance.newLevel(GameController.loadLevel());
            gameTimer.Start();
            lblLevelName.Text = currentGameInstance.MyLevel.LevelName;
          
        }
       // game control buttons
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
        // keys to control game
        public enum keys 
        {
            up = 'w', down = 's', left = 'a', right = 'd'
        }
        // acts on key press
        private void NewGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            // set the game area as focus
            pnlGame.Focus();
            // which key was pressed
            switch (e.KeyChar)
            {
                    // move theseus in relation to key pressed
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

        
        private void bntMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // returns the panel / game area
        public System.Windows.Forms.Panel getPanel()
        {
            System.Windows.Forms.Panel panel = pnlGame;
            return panel;
        }

        // what happens on a win or lose
        public void winLose(string state)
        {
            // stop the timer
            gameTimer.Stop();
            currentGameInstance.GameState = false;
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
            // add one to current time
            currentGameInstance.CurrentTime += 1;
            // calculate score
            currentGameInstance.CurrentScore -= currentGameInstance.CurrentTime * currentGameInstance.CurrentMoves;
            // show score
            lblScore.Text = currentGameInstance.CurrentScore.ToString();
            // show moves
            lblMoves.Text = currentGameInstance.CurrentMoves.ToString();
            // show time
            lblTime.Text = (currentGameInstance.CurrentTime / 60).ToString() + " : " + (currentGameInstance.CurrentTime % 60).ToString() ;
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // every tick update -- tick == 1000ms
            updatePlayer();
        }

        private void GamePlayerForm_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void GamePlayerForm_SizeChanged(object sender, EventArgs e)
        {

            currentGameInstance.buildCells();
        }
        
    }
}
