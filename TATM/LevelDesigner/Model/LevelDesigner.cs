using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign.Model
{
    public static class LevelDesigner
    {
        private static Level _MyLevel;
        public static Level MyLevel
        {
            get { return _MyLevel; }
            set { _MyLevel = value; }
        }
        #region Methods
        public static void GetImageForTileSet(string name, string img)
        {
            _MyLevel.TileSet.Add(name, img);
        }
        // creates level and adds it to current level
        public static void createLevel(int width, int height)
        {
            _MyLevel = new Level(width, height);
        }
        //public void createNewLevel();
        //public void shareLevel();
        //public void placeObject();
        //public void saveLevel();
        //public void loadLevel();
        //public void renderLevel();
        //public void getLevelData();
        //public void delete();
        //public void testLevel();
        //public void undo(); 
        #endregion
    }
}
