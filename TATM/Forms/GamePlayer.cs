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
using GamePlayer.Forms;


namespace GamePlayer
{
    public partial class GamePlayerForm : Form
    {
        // instance of game used by the form
        GameInstance currentGameInstance;
        private string selectedSave;

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
            updateSaves();
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
            setRatio();
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

            if ((Keys)e.KeyChar == Keys.Space)
            {
                this.currentGameInstance.moveMinotaur(2);
            }
        }

        private void lblMoves_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            CurrentGameInstance.undo();
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
            currentGameInstance.CurrentScore = 10000 - currentGameInstance.CurrentTime * currentGameInstance.CurrentMoves;
            // show score
            lblScore.Text = currentGameInstance.CurrentScore.ToString();
            // show moves
            lblMoves.Text = currentGameInstance.CurrentMoves.ToString();
            // show time
            lblTime.Text = (currentGameInstance.CurrentTime / 60).ToString() + "." + (currentGameInstance.CurrentTime % 60).ToString() ;
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // every tick update -- tick == 1000ms
            updatePlayer();
        }
        //sets the ratio for sprite sizing
        public void setRatio()
        {
            // width ad height are the same
            pnlGame.Width = pnlGame.Height;
            int pnlHeight = pnlGame.Height;
            // ratio is panel height divided by the amount of cells high
            int ratio = pnlHeight / (currentGameInstance.MyLevel.Height - 2);
            ratio -= (ratio / 13);
            // ratio for rendering is this ratio
            renderer.Ratio = ratio;
            // rebuild cells
            currentGameInstance.buildCells();

        }

        private void GamePlayerForm_ResizeEnd(object sender, EventArgs e)
        {
            // reset ratio
            setRatio();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (Form SaveGameForm = new SaveGame())
            {
                SaveGameForm.ShowDialog(this);
            }
            updateSaves();
        }

        public void updateSaves()
        {
            ltbSaves.Items.Clear();
            foreach (var file in System.IO.Directory.EnumerateFiles("../../Resources/XML/Saves/"))
            {
                string[] fileArray = file.Split('/');
                string filename = (string)fileArray.GetValue(fileArray.Length - 1);
                filename = filename.Remove(filename.Length - 4);
                ltbSaves.Items.Add(filename);
            }
            
        }

        private void ltbSaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbSaves.Items.Count >= ltbSaves.SelectedIndex)
            {
                selectedSave = (string)ltbSaves.Items[ltbSaves.SelectedIndex];
            }
        }

        private void btnLoadSave_Click(object sender, EventArgs e)
        {
            if (selectedSave != null)
            {
                List<string> instance = (List<string>)StorageManagement.Filer.loadFromFile(typeof(List<string>), "../../Resources/XML/saves/" + selectedSave);
                // create a new game instance
                currentGameInstance = new GameInstance();
                // set the panel as graphics location
                renderer.initialiseGraphics(getPanel().CreateGraphics());
                currentGameInstance.MyLevel = StorageManagement.StorageManagement.loadLevel(instance[0]);
                currentGameInstance.TheseusLocation = Convert.ToInt32(instance[1]);
                currentGameInstance.MinotaurLocation = Convert.ToInt32(instance[2]);
                currentGameInstance.CurrentMoves = Convert.ToInt32(instance[3]);
                currentGameInstance.CurrentTime = Convert.ToInt32(instance[4]);
                currentGameInstance.CanUndo = Convert.ToBoolean(instance[5]);
                gameTimer.Start();
                lblLevelName.Text = currentGameInstance.MyLevel.LevelName;
                setRatio();
                currentGameInstance.GameState = true;
            }
            else
            { 
                MessageBox.Show("Please select a level");
            }
        }
        
    }
}
