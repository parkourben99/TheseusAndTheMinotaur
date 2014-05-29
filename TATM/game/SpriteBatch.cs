using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GamePlayer.game
{
    // list of sprite data
    class SpriteBatch : List<Tuple<string, int, int>>
    {
        public void runBatch() 
        {
            // tells renderer to draw all the images in the batch
            foreach (Tuple<string, int, int> sprite in this)
            {
                GameController.CurrentGame.Renderer.drawRect(sprite);
            }
        }
        //adds a sprite to sprite batch
        public void addSprite(string item1, int item2, int item3) 
        {
            // tuple is image from tileset, x location, y location
            Tuple<string, int, int> sprite = new Tuple<string, int, int>(item1, item2, item3);
            this.Add(sprite);
        }
    }
}
