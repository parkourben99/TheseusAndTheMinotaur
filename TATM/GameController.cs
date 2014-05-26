using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelDesign.Model;
namespace GamePlayer.game
{
    static class GameController
    {
        //this is the current form being used for the game instance
        private static GamePlayerForm currentGame = new GamePlayerForm();
        public static GamePlayerForm CurrentGame
        {
            get { return currentGame; }
            set { currentGame = value; }
        }
        // opens load level form and returns level
        public static Level loadLevel()
        {
            // using the load level form
            using (var levelLoad = new LevelDesign.LevelSelect(StorageManagement.StorageManagement.getLevelList()))
            {
                // show the form
                levelLoad.ShowDialog();
                // return the selected level
                return StorageManagement.StorageManagement.loadLevel(levelLoad.selectedLevelName);
            }
        }
        public static void sendHighScores(string name, int score)
        {
            //StorageManagement.StorageManagement.addHighScore(name, score);
        }
    }


}
