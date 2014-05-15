using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StorageManagement;

namespace GamePlayer.game
{
    public class Reigndear
    {
        private Graphics graphics;

        public Reigndear()
        {
        }
        

        public void drawRect(Tuple<string, int, int, int, int> sprite)
        {
            Image img = Image.FromFile(sprite.Item1);
            Rectangle rect = new Rectangle(sprite.Item2, sprite.Item3, sprite.Item4, sprite.Item5);
            graphics.DrawImage(img, rect);
        }

        public void clearAll()
        {
            graphics.Clear(Color.Blue);
        }
        public void initialiseGraphics(Graphics newGraphics)
        {
            graphics = newGraphics;
        }
    }
}
