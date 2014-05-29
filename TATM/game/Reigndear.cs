using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StorageManagement;

namespace GamePlayer.game
{
    // the renderer for games graphics
    public class Reigndear
    {
        // the graphics to draw to
        private Graphics graphics;
        private int ratio;

        public int Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }
        public Reigndear()
        {

        }
        
        // draw image from image data to location
        public void drawRect(Tuple<string, int, int> sprite)
        {
            // set the image
            Image img = Image.FromFile(sprite.Item1);
            // set the draw shape
            Rectangle rect = new Rectangle(ratio * sprite.Item2, ratio * sprite.Item3,ratio, ratio);
            // tell graphics to draw
            graphics.DrawImage(img, rect);
        }

        public void clearAll()
        {
            // clears graphics with blue color
            graphics.Clear(Color.Black);
        }
        public void initialiseGraphics(Graphics newGraphics)
        {
            // set graphics
            graphics = newGraphics;
        }
    }
}
