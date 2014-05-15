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
        private static GamePlayerForm currentGame = new GamePlayerForm();
        public static GamePlayerForm CurrentGame
        {
            get { return currentGame; }
            set { currentGame = value; }
        }

        public static Level loadLevel()
        {
            using (var levelLoad = new LevelDesign.LevelSelect(StorageManagement.StorageManagement.getLevelList()))
            {
                levelLoad.ShowDialog();
                
                return StorageManagement.StorageManagement.loadLevel(levelLoad.selectedLevelName);
            }
        }
        public static void sendHighScores(string name, int score)
        {
            //StorageManagement.StorageManagement.addHighScore(name, score);
        }
    }


}
