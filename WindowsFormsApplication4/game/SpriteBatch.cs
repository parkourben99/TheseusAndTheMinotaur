using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GamePlayer.game
{
    class SpriteBatch : List<Tuple<string, int, int, int, int>>
    {
        public void runBatch() 
        {
            foreach (Tuple<string, int, int, int, int> sprite in this)
            {
                GameController.CurrentGame.Renderer.drawRect(sprite);
            }
        }
        public void addSprite(string item1, int item2, int item3, int item4, int item5) 
        {
            Tuple<string, int, int, int, int> sprite = new Tuple<string, int, int, int, int>(item1, item2, item3, item4, item5);
            this.Add(sprite);
        }
    }
}
